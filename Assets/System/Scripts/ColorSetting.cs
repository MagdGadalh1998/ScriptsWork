// System Created By:TarekNassef //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AccessColoring
{
    public class ColorSetting : MonoBehaviour
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
        public Color redColor;
        public Color orangeColor;
        public Color yellowColor;
        public Color pinkColor;
        public Color greenColor;
        public Color blueColor;/*
        public Color redColor;
        public Color redColor;*/

        [HideInInspector] public GameObject CountObjectsEffort;
        [HideInInspector] public GameObject CountObjectsFinished;

        [HideInInspector] public SpriteRenderer ImgColor;
        public static int IndexColor;
        public static int IndexPencil;
        public static string CurrentCol;

        public static bool ActivePencil;
        public static bool ActiveBrush;

        public static bool DisableColor;

        [Header("Information Color")]
        [ReadOnly] public string CurrentColor;
        [ReadOnly] public int ColorNumber;
        [ReadOnly] public int PencilNumber;
        [ReadOnly] public string Note1 = "Color Number = Static (Index Color)";
        [ReadOnly] public string Note2 = "Disable Coloring = Static (Disable Color)";

        [Header("Drawable Region")]
        public GameObject[] SpritesRegion;

        [Header("All Coloring")]
        public GameObject[] Coloring;

        [HideInInspector] public GameObject Brush_;
        [HideInInspector] public GameObject Pencil_;
        [HideInInspector] public GameObject BrushFake;
        [HideInInspector] public GameObject PencilFake;
        [HideInInspector] public GameObject BrushEmpty;
        [HideInInspector] public GameObject PencilEmpty;

        [Header("Brush Setting")]
        public int BrushWidth;
        public bool Brush;

        [Header("Pencil Setting")]
        public bool Pencil;

        [Header("Coloring Setting")]
        public bool DisableColoring;

        public static bool isCursorOverUI = false;
        [HideInInspector] public float Transparency = 1f;

        [Header("Documentation")]
        [ReadOnly] public string[] DocumentationColor;

        void Awake()
        {
            DisableColoring = false;
            DisableColor = false;

            ActivePencil = false;
            ActiveBrush = false;

            if (ActivePencil == false)
            {
                IndexColor = 0;
                CurrentColor = "No Color";
            }

            DocumentationColor = new string[9];
        }

        void Update()
        {
            Drawable.Brush_Width = BrushWidth;

            foreach (GameObject obj in Coloring)
            {
                if(!BrushEmpty.activeSelf)
                {
                    obj.gameObject.GetComponent<Button>().enabled = false;
                }
                else
                {
                    obj.gameObject.GetComponent<Button>().enabled = true;
                }
            }

            ActivePencil = Pencil;
            ActiveBrush = Brush;

            CurrentCol = CurrentColor;

            if (Brush == true)
            {
                if (PencilEmpty.activeSelf)
                {
                    Brush_.SetActive(false);
                    BrushFake.SetActive(true);
                }
                else
                {
                    Brush_.SetActive(true);
                    BrushFake.SetActive(false);
                }
            }
            else
            {
                Brush_.SetActive(false);
                BrushFake.SetActive(false);
            }

            if(GameManager.CountEffortsGlobal == false)
            {
                CountObjectsEffort.hideFlags = HideFlags.HideInHierarchy;
            }
            else
            {
                CountObjectsEffort.hideFlags = HideFlags.None;
            }

            if (GameManager.CountFinishedGlobal == false)
            {
                CountObjectsFinished.hideFlags = HideFlags.HideInHierarchy;
            }
            else
            {
                CountObjectsFinished.hideFlags = HideFlags.None;
            }

            if (Pencil == true)
            {
                if (BrushEmpty.activeSelf)
                {
                    Pencil_.SetActive(false);
                    PencilFake.SetActive(true);
                }
                else
                {
                    Pencil_.SetActive(true);
                    PencilFake.SetActive(false);
                }
            }
            else
            {
                Pencil_.SetActive(false);
                PencilFake.SetActive(false);
            }


            if (IndexColor == 9)
            {
                CurrentColor = "Pencil";
            }

            if (IndexColor == 10)
            {
                CurrentColor = "Empty";
            }

            if (ColorNumber == 10)
            {
                foreach (GameObject obj in SpritesRegion)
                {
                    obj.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
            }

            if (DisableColoring == true)
            {
                DisableColor = true;
                foreach(GameObject obj in SpritesRegion)
                {
                    obj.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
            }

            if (DisableColoring == false && ColorNumber == 0 && PencilNumber == 0)
            {
                DisableColor = false;
                foreach (GameObject obj in SpritesRegion)
                {
                    obj.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    obj.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
            }

            if (DisableColoring == false)
            {
                DisableColor = false;
                foreach (GameObject obj in SpritesRegion)
                {
                    obj.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                    obj.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                }
            }

            foreach (string item in DocumentationColor)
            {
                DocumentationColor = new string[10];

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

            ColorNumber = IndexColor;
            PencilNumber = IndexPencil;
        }

        public void SetMarkerColour(Color new_color)
        {
            Drawable.Pen_Colour = new_color;
        }

        public void EraserNew(Color Eras)
        {
        }

        public void SetMarkerWidth(int new_width)
        {
            Drawable.Pen_Canves = new_width;
        }
        public void SetMarkerWidth(float new_width)
        {
            SetMarkerWidth((int)new_width);
        }

        public void SetTransparency(float amount)
        {
            Transparency = amount;
            Color c = Drawable.Pen_Colour;
            c.a = amount;
            Drawable.Pen_Colour = c;
        }


        public void Eraser()
        {
            Color c = Color.white;
            c.a = Transparency;
            SetMarkerColour(c);
        }

        public void Pencili()
        {
            Color c = Color.black;
            c.a = Transparency;
            SetMarkerColour(c);
            IndexColor = 10;
            CurrentColor = "Pencil";
        }

        public void SetMarkerGreenDark()
        {
            Color c = new Color32(0, 123, 66, 255);
            c.a = Transparency;
            SetMarkerColour(c);
            IndexColor = 6;
            CurrentColor = "Green Dark";
        }

        public void SetMarkerCyan()
        {
            Color c = Color.cyan;
            c.a = Transparency;
            SetMarkerColour(c);
            IndexColor = 7;
            CurrentColor = "Cyan";
        }


        public void SetMarkerMagenta()
        {
            Color c = pinkColor;
            c.a = Transparency;
            SetMarkerColour(c);
            IndexColor = 8;
            CurrentColor = "Magenta";
        }

        public void SetMarkerOrange()
        {
            Color c = orangeColor;
            c.a = Transparency;
            SetMarkerColour(c);
            IndexColor = 2;
            CurrentColor = "Orange";
        }

        public void SetMarkerYellow()
        {
            Color c = yellowColor;
            c.a = Transparency;
            SetMarkerColour(c);
            IndexColor = 3;
            CurrentColor = "Yellow";
        }

        public void SetMarkerRed()
        {
            Color c = Color.red;
            c.a = Transparency;
            SetMarkerColour(c);
            IndexColor = 1;
            CurrentColor = "Red";
        }
        public void SetMarkerGreen()
        {
            Color c = greenColor;
            c.a = Transparency;
            SetMarkerColour(c);
            IndexColor = 4;
            CurrentColor = "Green";
        }
        public void SetMarkerBlue()
        {
            Color c = blueColor;
            c.a = Transparency;
            SetMarkerColour(c);
            IndexColor = 5;
            CurrentColor = "Blue";
        }
        public void SetEraser()
        {
            EraserNew(new Color(0f, 0f, 0f, 0f));
        }

        public void PartialSetEraser()
        {
            EraserNew(new Color(0f, 0f, 0f, 0f));
        }
    }
}