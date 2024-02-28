using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControl : MonoBehaviour
{
    public int ColorStatus;

    void Start()
    {

    }

    void Update()
    {
        if(ColorStatus == 0)
        {
            AccessDrawingSetting.DrawingSettings.IndexColor = ColorStatus;
        }
    }
}
