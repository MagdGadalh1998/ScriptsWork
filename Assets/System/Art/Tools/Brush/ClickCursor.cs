using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCursor : MonoBehaviour
{
    public GameObject ActiveScript;
    public GameObject ActiveEmpty;
    public GameObject ActiveUnClick;
    public static bool StopBrush;

    public GameObject PencilCollider;
    public static bool Brush_Working;

    public GameObject PencilOriginal;
    public GameObject PencilFake;
    void Start()
    {
        Cursor.visible = true;
        StopBrush = false;
        Brush_Working = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && StopBrush == false)
        {
            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                         Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
            
            if (hit.collider != null && hit.collider.tag == "BrushFull")
            {
                print("Brush Working Now");
                ActiveScript.gameObject.GetComponent<MoveBrushCur>().enabled = true;
                ActiveEmpty.SetActive(true);
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                ActiveUnClick.SetActive(true);
                PencilCollider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Brush_Working = true;

            }
            
            

        }
    }
}
