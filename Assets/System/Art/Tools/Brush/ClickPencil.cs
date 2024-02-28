using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPencil : MonoBehaviour
{
    public GameObject ActiveScript;
    public GameObject ActiveEmpty;
    public GameObject ActiveUnClick;
    public static bool StopBrush;
    public static bool Pencil_Working;

    public GameObject BrushCollider;
    void Start()
    {
        Cursor.visible = true;
        StopBrush = false;
        Pencil_Working = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && StopBrush == false)
        {
            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                         Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
            
            if (hit.collider != null && hit.collider.tag == "PencilFull")
            {
                print("Pencil Working Now");
                AccessColoring.ColorSetting.IndexPencil = 100;
                Pencil_Working = true;
                ActiveScript.gameObject.GetComponent<MoveBrushPen>().enabled = true;
                ActiveEmpty.SetActive(true);
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                ActiveUnClick.SetActive(true);
                BrushCollider.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            }
            
            

        }
    }
}
