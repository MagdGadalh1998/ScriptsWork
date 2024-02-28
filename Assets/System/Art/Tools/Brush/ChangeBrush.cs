using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBrush : MonoBehaviour
{
    public GameObject ActiveScript;
    public GameObject ThisTransform;
    public GameObject ActiveBoxCollider;
    public GameObject BrushEmpty;
    public GameObject CursorPosition;
    public GameObject BrushPosition;
    public GameObject BoxPosition;
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
                Debug.Log("OK Tag");
                ActiveScript.gameObject.GetComponent<MoveBrushCur>().enabled = false;
                Cursor.visible = true;
                ActiveBoxCollider.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                ClickCursor.StopBrush = false;
                BrushEmpty.SetActive(false);
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;


            }
        }
    }



    public void HideBrush()
    {
        ClickCursor.StopBrush = true;
        ActiveScript.transform.position = CursorPosition.transform.position;
        BrushPosition.transform.position = BoxPosition.transform.position;
        Cursor.visible = true;
        Debug.Log("Drawing Finished");

        ActiveScript.gameObject.GetComponent<MoveBrushCur>().enabled = false;
        ActiveBoxCollider.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        ClickCursor.StopBrush = false;
        BrushEmpty.SetActive(false);
        this.gameObject.SetActive(false);

    }
}
