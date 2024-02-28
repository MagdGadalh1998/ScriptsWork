using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class Drawable : MonoBehaviour
{
    public static bool DrawingNow;
    [HideInInspector] public bool Pressed;

    [HideInInspector] public GameObject DrawSett;

    [HideInInspector] public GameObject BrushEmpty;
    [HideInInspector] public GameObject PencilEmpty;

    public static int IndexCur;

    [HideInInspector] public SpriteRenderer DrawableSprite;

    public static Color Pen_Colour = Color.red;
    [HideInInspector] public int Pen_Width = 10;
    [HideInInspector] public GameObject Transparent;

    public static int Brush_Width;

    public static int Pen_Canves;


    public static Color Pencil_color = Color.black;


    public delegate void Brush_Function(Vector2 world_position);
    public Brush_Function current_brush;

    public LayerMask Drawing_Layers;

    public bool Reset_Canvas_On_Play = true;
    public Color Reset_Colour = new Color(0, 0, 0, 0);

    Sprite drawable_sprite;
    Texture2D drawable_texture;

    Vector2 previous_drag_position;
    Color[] clean_colours_array;
    Color transparent;
    Color32[] cur_colors;
    bool mouse_was_previously_held_down = false;
    bool no_drawing_on_current_drag = false;

    [HideInInspector] public float FillPercentage = .97f;

    public void SetMarkerWidth(float new_width)
    {

        new_width = Transparent.gameObject.GetComponent<Slider>().value;
        Pen_Width = Mathf.RoundToInt(new_width);
    }

    public void BrushTemplate(Vector2 world_position)
    {
        pixel_pos = WorldToPixelCoordinates(world_position);

        cur_colors = drawable_texture.GetPixels32();

        if (previous_drag_position == Vector2.zero)
        {
            MarkPixelsToColour(pixel_pos, Pen_Width, Pen_Colour);
        }
        else
        {
            ColourBetween(previous_drag_position, pixel_pos, Pen_Width, Pen_Colour);
        }

        ApplyMarkedPixelChanges();

        previous_drag_position = pixel_pos;
    }

    Vector2 pixel_pos;
    public void PenBrush(Vector2 world_point)
    {
        pixel_pos = WorldToPixelCoordinates(world_point);

        cur_colors = drawable_texture.GetPixels32();

        if (previous_drag_position == Vector2.zero)
        {
            MarkPixelsToColour(pixel_pos, Pen_Width, Pen_Colour);
        }
        else
        {
            ColourBetween(previous_drag_position, pixel_pos, Pen_Width, Pen_Colour);
        }
        ApplyMarkedPixelChanges();

        previous_drag_position = pixel_pos;
    }

    public void SetPenBrush()
    {
        current_brush = PenBrush;
    }

    Vector2 mouse_world_position;
    bool mouse_held_down;

    Vector2 lastMousePos = new Vector2(99999, 99999);
    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            if (AccessDrawingSetting.DrawingSettings.IndexColor != 0 || AccessDrawingSetting.DrawingSettings.IndexPencil != 0)
            {
                if (BrushEmpty.activeSelf || PencilEmpty.activeSelf)
                {
                    if (!mouse_held_down)
                    {
                        DrawingNow = true;
                        mouse_held_down = true;
                        previous_drag_position = Vector2.zero;
                    }

                    mouse_world_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    if (Vector3.Distance(lastMousePos, mouse_world_position) > .001f)
                    {
                        current_brush(mouse_world_position);
                    }
                    lastMousePos = mouse_world_position;
                }
            }
        }
        else
        {
            mouse_held_down = false;
            DrawingNow = false;
            Pressed = false;
        }
    }

    private void OnMouseExit()
    {
        mouse_held_down = false;
        Pressed = false;

    }
    float timer;
    private void Update()
    {
        if (AccessDrawingSetting.DrawingSettings.IndexColor == 0 && AccessDrawingSetting.DrawingSettings.IndexPencil != 0 && BrushEmpty.activeSelf)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

            if (ClickPencil.Pencil_Working == true)
        {
            Pen_Colour = Pencil_color;
            Pen_Width = 3;
        }
        else
        {
            Pen_Width = Brush_Width;
        }

        FillPercentage = DrawSett.gameObject.GetComponent<AccessDrawingSetting.DrawingSettings>().FillPercentageDraw;

        if (DrawSett.gameObject.GetComponent<AccessDrawingSetting.DrawingSettings>().DeleteDrawing == true)
        {
            ResetCanvas();
        }

        if (Input.GetMouseButtonUp(0) && DrawSett.gameObject.GetComponent<AccessDrawingSetting.DrawingSettings>().Infinity == false)
        {
            if ((float)coloredPixels / maxPixels > FillPercentage)
            {
                OnFinish();
            }
        }
        if(mouse_held_down==true)
        {
            timer += Time.deltaTime;
            if(timer>.5f)
            {
                if (DrawSett.gameObject.GetComponent<AccessDrawingSetting.DrawingSettings>().StateIndex != IndexCur)
                {
                    DrawSett.gameObject.GetComponent<AccessDrawingSetting.DrawingSettings>().IndexDisable = true;
                }
                else
                {
                    DrawSett.gameObject.GetComponent<AccessDrawingSetting.DrawingSettings>().IndexDisable = false;
                }

                timer = 0;
                if ((float)coloredPixels / maxPixels > FillPercentage)
                {
                    if (DrawSett.gameObject.GetComponent<AccessDrawingSetting.DrawingSettings>().Infinity == false)
                    {
                        OnFinish();
                    }
                }
            }

        }
    }

    public void ColourBetween(Vector2 start_point, Vector2 end_point, int width, Color color)
    {
        float distance = Vector2.Distance(start_point, end_point);
        Vector2 direction = (start_point - end_point).normalized;

        Vector2 cur_position = start_point;

        float lerp_steps = 1 / distance;

        for (float lerp = 0; lerp <= 1; lerp += lerp_steps)
        {
            cur_position = Vector2.Lerp(start_point, end_point, lerp);
            MarkPixelsToColour(cur_position, width, color);
        }
    }

    int center_x, center_y, pen_thicknessX, pen_thicknessY;
    bool isFinished;

    public void MarkPixelsToColour(Vector2 center_pixel, int pen_thickness, Color color_of_pen)
    {
        center_x = (int)center_pixel.x;
        center_y = (int)center_pixel.y;
        pen_thicknessX = (int)(pen_thickness / transform.lossyScale.x);
        pen_thicknessY = (int)(pen_thickness / transform.lossyScale.y);

        rSquared = (int)(pen_thicknessX * pen_thicknessY);

        for (int x = center_x - pen_thicknessX; x <= center_x + pen_thicknessX; x++)
        {
            if (x >= (int)drawable_sprite.rect.width || x < 0)
                continue;

            for (int y = center_y - pen_thicknessY; y <= center_y + pen_thicknessY; y++)
            {
                if ((center_x - x) * (center_x - x) + (center_y - y) * (center_y - y) < rSquared)
                {
                    MarkPixelToChange(x, y, color_of_pen);
                }
            }
        }
        if (!isFinished)
        {
            isFinished = true;
            for (int i = 1; i < coloredColumns.Length-1; i++)
            {
                if (coloredColumns[i] < height - 3)
                {
                    isFinished = false;
                }
            }
            if (isFinished)
            {
                isFinished = false;
                OnFinish();
            }
        }
    }

    void OnFinish()
    {
        if (!isFinished)
        {
            isFinished = true;
            print("Drawing Finished");
            Reset_Canvas_On_Play = false;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if(!isColored[i,j])
                    {
                        MarkPixelToChange(i, j, Pen_Colour);
                    }
                }
            }
            ApplyMarkedPixelChanges();

        }
    }
    float rSquared;
    int array_pos;
    public void MarkPixelToChange(int x, int y, Color color)
    {

        array_pos = y * (int)drawable_sprite.rect.width + x;

        if (array_pos >= cur_colors.Length || array_pos < 1)
            return;

        if (y == height)
        {
            y = 0;
        }
        if (x == width)
        {
            x = 0;
        }

        color.a = croppedTexture.GetPixel(x, y).a;
        cur_colors[array_pos] = color;
        if (!isColored[x, y])
        {
            isColored[x, y] = true;
            ++coloredColumns[x];
            ++coloredPixels;


            if (array_pos > 5000 && isColored[x, y] == true && timer > .40f && coloredPixels > 5000)
            {
                Pressed = true;
            }
        }
    }
    public void ApplyMarkedPixelChanges()
    {
        drawable_texture.SetPixels32(cur_colors);
        drawable_texture.Apply();
    }


    public void ColourPixels(Vector2 center_pixel, int pen_thickness, Color color_of_pen)
    {
        int center_x = (int)center_pixel.x;
        int center_y = (int)center_pixel.y;
        int pen_thicknessX = (int)(pen_thickness);
        int pen_thicknessY = (int)(pen_thickness);

        for (int x = center_x - pen_thicknessX; x <= center_x + pen_thicknessX; x++)
        {
            for (int y = center_y - pen_thicknessY; y <= center_y + pen_thicknessY; y++)
            {
                if ((center_x - x) * (center_x - x) + (center_y - y) * (center_y - y) < rSquared)
                {
                    drawable_texture.SetPixel(x, y, color_of_pen);
                }
            }
        }

    }

    public Vector2 WorldToPixelCoordinates(Vector2 world_position)
    {
        Vector3 local_pos = transform.InverseTransformPoint(world_position);

        float pixelWidth = drawable_sprite.rect.width;
        float pixelHeight = drawable_sprite.rect.height;
        float unitsToPixels = pixelWidth / drawable_sprite.bounds.size.x;

        float centered_x = local_pos.x * unitsToPixels + pixelWidth / 2;
        float centered_y = local_pos.y * unitsToPixels + pixelHeight / 2;

        Vector2 pixel_pos = new Vector2(Mathf.RoundToInt(centered_x), Mathf.RoundToInt(centered_y));

        return pixel_pos;
    }

    public void ResetCanvas()
    {
        drawable_texture.SetPixels(clean_colours_array);
        drawable_texture.Apply();
    }

    [SerializeField] int width = 50, height = 100;
    bool[,] isColored;
    [SerializeField] int[] coloredColumns;
    [SerializeField] SpriteRenderer parentSpriteRenderer;
    void Awake()
    {
        FillPercentage = AccessDrawingSetting.DrawingSettings.FillRate;

        current_brush = PenBrush;
        CreateTempSprite();
    }

    private void OnDestroy()
    {
        ResetCanvas();
    }
    SpriteRenderer spriteRenderer;
    void CreateTempSprite()
    {
        if (parentSpriteRenderer)
        {
            width = (int)parentSpriteRenderer.sprite.textureRect.width;
            height = (int)parentSpriteRenderer.sprite.textureRect.height;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        Texture2D tex = new Texture2D(width, height, TextureFormat.ARGB32, false);
        spriteRenderer.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), parentSpriteRenderer.sprite.pixelsPerUnit);

        drawable_sprite = this.GetComponent<SpriteRenderer>().sprite;
        drawable_texture = drawable_sprite.texture;

        clean_colours_array = new Color[(int)drawable_sprite.rect.width * (int)drawable_sprite.rect.height];
        for (int x = 0; x < clean_colours_array.Length; x++)
            clean_colours_array[x] = Reset_Colour;
        if (Reset_Canvas_On_Play)
            ResetCanvas();

        AdjustBoxCollider();

        isColored = new bool[width, height];
        coloredColumns = new int[width];
        HideAlphaPixels();
    }

    void ActiveCollider()
    { 
    }

    void AdjustBoxCollider()
    {
        BoxCollider2D boxCollider;
        boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            boxCollider = gameObject.AddComponent<BoxCollider2D>();
            boxCollider.gameObject.hideFlags = HideFlags.HideInInspector;
        }

        if (DrawableSprite.gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            if(BrushEmpty.activeSelf || PencilEmpty.activeSelf)
            {
                boxCollider.enabled = false;
            }
        }

        Vector2 colliderSize = new Vector2((float)width, (float)height) / (parentSpriteRenderer.sprite.pixelsPerUnit / 100) / 100;
        colliderSize.x += (Pen_Width / 50);
        colliderSize.y += (Pen_Width / 50);
        boxCollider.size = colliderSize;
        boxCollider.isTrigger = true;
    }
    Texture2D croppedTexture;
    int coloredPixels, maxPixels;
    void HideAlphaPixels()
    {
        croppedTexture = new Texture2D((int)parentSpriteRenderer.sprite.rect.width, (int)parentSpriteRenderer.sprite.rect.height);
        var pixels = parentSpriteRenderer.sprite.texture.GetPixels((int)parentSpriteRenderer.sprite.rect.x,
                                    (int)parentSpriteRenderer.sprite.rect.y,
                                    (int)parentSpriteRenderer.sprite.rect.width,
                                    (int)parentSpriteRenderer.sprite.rect.height);
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();

        maxPixels = width * height;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (croppedTexture.GetPixel(i, j).a <= 0||i==0||j==0||i==width-1||j==height-1)
                {
                    isColored[i, j] = true;
                    ++coloredColumns[i];
                    --maxPixels;
                }
            }
        }
        parentSpriteRenderer.color *= 0;
    }
    int num;
    private void OnTriggerStay2D(Collider2D collision)
    {
        OnMouseOver();
    }
}
