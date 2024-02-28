using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class GameManager : MonoBehaviour
{
    [Header("Counting")]
    public bool CountEfforts;
    public static bool CountEffortsGlobal;
    public bool CountFinished;
    public static bool CountFinishedGlobal;
    
    void Start()
    {
        Drawing1Finished = false;
        Drawing1Index = false;

        if (CountEfforts == false)
        {
            CountEffortsGlobal = false;
        }
        else
        {
            CountEffortsGlobal = true;
        }

        if (CountFinished == false)
        {
            CountFinishedGlobal = false;
        }
        else
        {
            CountFinishedGlobal = true;
        }
    }
    private void Update()
    {
        Drawing1();
        NotColor1();
        
    }
    
}
