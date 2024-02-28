// Coloring System Created By:TarekNassef //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AccessDrawingSetting
{
    // Helper methods used to set drawing settings
    public class DrawingSettings : MonoBehaviour
    {
        // Read This to Access Color - By:TarekNassef //
        // [ Color Controller Access]
        // Non Color = 0
        // Red = 1
        // Orange = 2
        // Yellow = 3
        // Green = 4
        // Blue = 5
        // GreenDark = 6
        // Cyan = 7
        // Magenta = 8

       [HideInInspector] public Drawable draw;

       public static int IndexColor;
       public static int IndexPencil;
       public static bool DisableDraw;
       public static bool DeleteDraw;
       public static bool FinishDraw;
       public static bool InfiniteCheck;

       [HideInInspector] public bool IndexDisable;
       public static int IndexCheck;

       public static float FillRate;

       [HideInInspector] public SpriteRenderer DrawOnFinish;
       [HideInInspector] public SpriteRenderer DrawOnRegion;
       [HideInInspector] public GameObject Drawabling;

       [HideInInspector] public GameObject BrushFake;
       [HideInInspector] public GameObject PencilFake;
       [HideInInspector] public GameObject BrushEmpty;

       [Header("Information Color")]
       [ReadOnly] public string CurrentColor;
       [ReadOnly] public int ColorNumber;
       [ReadOnly] public int PencilNumber;
       [ReadOnly] public string[] Notes;

       [Header("Drawing Details")]
       public float FillPercentageDraw = 0.94f;
       public int ChooseIndex;
       [ReadOnly] public int StateIndex;
       public bool EnableIndex;
       public bool Infinity;
       public bool ShowDrawing;
       public bool DeleteDrawing;
       [ReadOnly] public bool DisableDrawing;
       [ReadOnly] public bool FinishDrawing;
       [ReadOnly] public bool IndexNull;

       [Header("Documentation")]
       [ReadOnly] public string[] DocumentationColor;

       public static bool isCursorOverUI = false;
       [HideInInspector] public float Transparency = 1f;

        void Awake()
        {
            DrawOnFinish.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            DrawOnFinish.gameObject.hideFlags = HideFlags.HideInInspector;

            IndexColor = 0;
            IndexPencil = 0;
            CurrentColor = "No Color";

            DisableDraw = false;
            DisableDrawing = false;

            DeleteDraw = false;
            DeleteDrawing = false;

            FinishDraw = false;
            FinishDrawing = false;

            DocumentationColor = new string[9];
            Notes = new string[5];

            FillRate = FillPercentageDraw;
        }

        void Update()
        {
            Drawable.IndexCur = ChooseIndex;
            IndexCheck = StateIndex;
            IndexPencil = PencilNumber;
            StateIndex = ColorIndex.IndexManual;
            if (StateIndex != ChooseIndex && EnableIndex == true && !BrushFake.activeSelf && BrushEmpty.activeSelf && draw.gameObject.GetComponent<Drawable>().Pressed == true)
            {
                if(PencilNumber == 100 || PencilNumber == 0 && ColorNumber != 0 || ColorNumber == 0)
                {
                    IndexNull = true;
                    draw.ResetCanvas();
                    Drawabling.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
            else
            {
                IndexNull = false;
                Drawabling.gameObject.GetComponent<BoxCollider2D>().enabled = true;;
            }

            if (Infinity == true)
            {
                InfiniteCheck = true;
            }
            else
            {
                InfiniteCheck = false;
            }

            FillRate = FillPercentageDraw;
            IndexPencil = AccessColoring.ColorSetting.IndexPencil;
            IndexColor = AccessColoring.ColorSetting.IndexColor;
            CurrentColor = AccessColoring.ColorSetting.CurrentCol;

            if (IndexColor == 9)
            {
                CurrentColor = "Pencil";
            }

            if (IndexColor == 10)
            {
                CurrentColor = "Empty";
            }

            foreach (string item in DocumentationColor)
            {
                DocumentationColor = new string[10]; // Set Size Of Documentation

                DocumentationColor[0] = "Color Number 0 = No Color";
                DocumentationColor[1] = "Color Number 1 = Red";
                DocumentationColor[2] = "Color Number 2 = Orange";
                DocumentationColor[3] = "Color Number 3 = Yellow";
                DocumentationColor[4] = "Color Number 4 = Green";
                DocumentationColor[5] = "Color Number 5 = Blue";
                DocumentationColor[6] = "Color Number 6 = Green Dark";
                DocumentationColor[7] = "Color Number 7 = Cyan";
                DocumentationColor[8] = "Color Number 8 = Magenta";
                DocumentationColor[9] = "Color Number 100 = Pencil";

            }

            foreach (string Note in Notes)
            {
                Notes = new string[5]; // Set Notes

                Notes[0] = "Color Number = Static (Index Color)";
                Notes[1] = "Disable Drawing = Disable Coloring";
                Notes[2] = "Delete Drawing = Static (Delete Draw)";
                Notes[3] = "Finish Drawing = Static (Finish Draw)";
                Notes[4] = "Number 100 With Pencil (Not select with any Color)";
            }

            ColorNumber = IndexColor;
            PencilNumber = IndexPencil;
            DisableDraw = DisableDrawing;
            DeleteDraw = DeleteDrawing;

            if (AccessColoring.ColorSetting.DisableColor == true)
            {
                DisableDrawing = true;
            }
            else
            {
                DisableDrawing = false;
            }

            if (DeleteDrawing == true)
            {
                DeleteDraw = true;
            }
            else
            {
                DeleteDraw = false;
            }

            if (draw.gameObject.GetComponent<Drawable>().Reset_Canvas_On_Play == false && Infinity != true)
            {
                FinishDrawing = true;

                if(ShowDrawing == false)
                {
                    DrawOnFinish.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    DrawOnRegion.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
    }
}