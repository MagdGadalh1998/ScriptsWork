using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorIndex : MonoBehaviour
{
    public int IndexColor;
    public static int IndexManual;

    public void Update()
    {
        
    }
    public void Index()
    {
        IndexManual = IndexColor;
    }
}
