using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnClickCursor : MonoBehaviour
{
    public GameObject ActiveClick;
    public GameObject DisactiveUnClick;


    public GameObject Brush;
    public GameObject BrushHead;

    public GameObject BrushReset;
    void Start()
    {
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && ClickCursor.StopBrush == true)
        {
            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                         Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
            
            if (hit.collider != null && hit.collider.tag == "BrushEmpty")
            {
                
                Brush.gameObject.GetComponent<FollowMouse>().enabled = false;
                BrushHead.gameObject.GetComponent<FollowMouse>().enabled = false;

                ActiveClick.gameObject.SetActive(true);

                ActiveClick.gameObject.GetComponent<ClickCursor>().enabled = true;
                ActiveClick.gameObject.GetComponent<BoxCollider2D>().enabled = true;

                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                this.gameObject.GetComponent<UnClickCursor>().enabled = false;
                DisactiveUnClick.gameObject.SetActive(false);

                Brush.transform.position = BrushReset.transform.position;

                Cursor.visible = true;
                ClickCursor.StopBrush = false;
            }
        }
    }
}
