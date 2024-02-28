using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOnFinished : MonoBehaviour
{
    public GameObject DrawOn;
    public GameObject DrawOnFinish;
    [ReadOnly] public bool DrawFinished;
    void Start()
    {
        DrawFinished = false;
    }

    void Update()
    {
        if(DrawOnFinish.gameObject.GetComponent<SpriteRenderer>().enabled == true)
        {
            DrawOn.SetActive(false);
            DrawFinished = true;
        }
    }
}
