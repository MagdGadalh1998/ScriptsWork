using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBrush : MonoBehaviour
{
    public GameObject ActiveScript;
    public GameObject ThisTransform;
    public GameObject ActiveBoxCollider;
    public GameObject BrushEmpty;
    public GameObject PencilCollider;

    public GameObject PencilOriginal;
    public GameObject PencilFake;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0) && ClickCursor.StopBrush == true)
        {
            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                         Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
            if (hit.collider.tag == "BrushEmpty")
            {
                print("OK Tag");
                ActiveScript.gameObject.GetComponent<MoveBrushCur>().enabled = false;
                Cursor.visible = true;
                ActiveBoxCollider.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                ClickCursor.StopBrush = false;
                BrushEmpty.SetActive(false);
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                ClickCursor.Brush_Working = false;

            }
        }
    }



    public void HideBrush()
    {
        ClickCursor.StopBrush = true;
        ActiveScript.transform.position = this.transform.position;
        Cursor.visible = true;
        print("Brush Reset Again");

        ActiveScript.gameObject.GetComponent<MoveBrushCur>().enabled = false;
        ActiveBoxCollider.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        ClickCursor.StopBrush = false;
        BrushEmpty.SetActive(false);
        this.gameObject.SetActive(false);
        PencilCollider.gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }
}
