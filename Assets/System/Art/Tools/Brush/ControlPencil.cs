using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPencil : MonoBehaviour
{
    public GameObject ActiveScript;
    public GameObject ThisTransform;
    public GameObject ActiveBoxCollider;
    public GameObject BrushEmpty;

    public GameObject BrushHead;
    public GameObject BrushCollider;
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
            if (hit.collider.tag == "PencilEmpty")
            {
                Debug.Log("OK Tag");
                ActiveScript.gameObject.GetComponent<MoveBrushPen>().enabled = false;
                Cursor.visible = true;
                ActiveBoxCollider.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                ClickCursor.StopBrush = false;
                BrushEmpty.SetActive(false);
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;


            }
        }
    }



    public void HidePencil()
    {
        ClickCursor.StopBrush = true;
        ActiveScript.transform.position = this.transform.position;
        Cursor.visible = true;
        print("Brush Reset Again");
        ClickPencil.Pencil_Working = false;
        if(BrushHead.gameObject.GetComponent<Image>().color == new Color32(0,0,0,0))
        {
            AccessColoring.ColorSetting.IndexPencil = 100;
            AccessDrawingSetting.DrawingSettings.IndexPencil = 100;
            print("Brush No Color");
        }

        Drawable.Pen_Colour = ColorManager.currentColor;
        ActiveScript.gameObject.GetComponent<MoveBrushPen>().enabled = false;
        ActiveBoxCollider.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        ClickCursor.StopBrush = false;
        BrushEmpty.SetActive(false);
        this.gameObject.SetActive(false);
        BrushCollider.gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }
}
