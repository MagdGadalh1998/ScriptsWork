using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBrushCur : MonoBehaviour
{
    void Start()
    {
        
    }

    
    void Update()
    {
        if(ClickCursor.StopBrush == false)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0.21f, 0f, 9f);
            Cursor.visible = false;
        }

    }
}
