using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class ColorManager : MonoBehaviour
{
    [SerializeField] Image bruchColorImg;
    public static Color32 currentColor = new Color32(0, 0, 0, 0);
    public Color32 ResetColor = new Color32(0, 0, 0, 0);

    public UnityEvent onColorChange;
    public static ColorManager singleton;
    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        ChangeDrawingColor(ResetColor);
    }

    public void ChangeDrawingColor(Image image)
    {
        ChangeDrawingColor(image.color);
    }

    public void ChangeDrawingColor(Color color)
    {
        currentColor = color;
        bruchColorImg.color = color;
        onColorChange.Invoke();
    }
}
