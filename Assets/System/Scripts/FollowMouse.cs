using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0.37f, 0.15f, 9f);
        Cursor.visible = false;
    }
}
