using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BrushController : MonoBehaviour
{
    Camera cam;
    Vector3 newPosition;
    Color appliedColor;
    Vector3 offset;
    [SerializeField] bool applyOnEnter;
    void Awake()
    {
        cam = Camera.main;
        appliedColor = Color.white;
    }

    private void Start()
    {
    }

    void Update()
    {
    }
    public void MouseDrag()
    {
        newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 20;
        transform.position = newPosition;
        Cursor.visible = false;
    }
    public void OnBeginDrag()
    {
        offset = transform.parent.position - transform.position;
    }
    public void OnDragEnd()
    {
        
        transform.position=transform.parent.position-offset;
        if(appliedColor != Color.white)
        {
            ColorManager.singleton.ChangeDrawingColor(appliedColor);
        }
        Cursor.visible = true;
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Color")
        {
            appliedColor = collision.gameObject.GetComponentInChildren<Image>().color;
            if (applyOnEnter)
            {
                ColorManager.singleton.ChangeDrawingColor(appliedColor);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        appliedColor= Color.white;
    }
}
