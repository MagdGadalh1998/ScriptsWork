using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager
{
    [Header("Drawing 1")]
    public GameObject Draw1;
    public GameObject Prefab1;
    public GameObject EffortsPosition1;
    public GameObject FinishedPosition1;
    [ReadOnly] public bool Drawing1Index;
    [ReadOnly] public bool Drawing1Finished;
    [ReadOnly] public bool Drawing1False;

    private void Drawing1()
    {
        bool CheckIfFinished1 = GameObject.FindWithTag("Drawing 1").GetComponent<AccessDrawingSetting.DrawingSettings>().FinishDrawing;

        if (CheckIfFinished1 == true && Drawing1Finished == false && Draw1.gameObject.GetComponent<Drawable>().Reset_Canvas_On_Play == false)
        {
            Drawing1Finished = true;

            if (CountFinished == true)
            {
                var NewGameObject = Instantiate(Prefab1, transform.position, transform.rotation);
                NewGameObject.transform.parent = gameObject.transform;
                NewGameObject.transform.parent = FinishedPosition1.transform;
            }

            if (CountObjectsFinished.FinishedNumbers == true)     // Pictures Drawing Number Selected is Finished
            {

                // Write Here What Do You Want If Finished Numbers is Finished //
            }

            print("Drawing 1 Function Active");
        }
    }
    

    private void NotColor1() // Check Drawing Color Index
    {
        bool Index1 = GameObject.FindWithTag("Drawing 1").GetComponent<AccessDrawingSetting.DrawingSettings>().IndexNull;

        if (Index1 == true && Drawing1Index == false && Draw1.gameObject.GetComponent<Drawable>().Pressed == true && Drawing1Finished != true)
        {
            Drawing1Index = true;
            Drawing1False = true;

            if(CountEfforts == true)
            {
                var NewGameObject = Instantiate(Prefab1, transform.position, transform.rotation);
                NewGameObject.transform.parent = gameObject.transform;
                NewGameObject.transform.parent = EffortsPosition1.transform;

            }

            if(CountObjectsEfforts.EffortNumbers == true)     // Efforts Drawing Number Selected is Finished
            {
                // Write Here What Do You Want If Effort Numbers is Finished //
            }

            StartCoroutine(Reset1());
            print("Drawing 1 Not Corrent Coloring");
        }
    }
    IEnumerator Reset1()
    {
        yield return new WaitForSeconds(2);
        Draw1.gameObject.GetComponent<Drawable>().Pressed = false;
        Drawing1Index = false;
    }
}
