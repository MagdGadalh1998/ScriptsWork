using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionMatches : MonoBehaviour
{
    public GameObject Brush;
    public GameObject BrushFake;
    public GameObject Pencil;
    public GameObject PencilFake;

    void Awake()
    {
        PencilFake.transform.position = Pencil.transform.position;
        BrushFake.transform.position = Brush.transform.position;
    }

    void Update()
    {
        PencilFake.transform.position = Pencil.transform.position;
        BrushFake.transform.position = Brush.transform.position;
    }
}
