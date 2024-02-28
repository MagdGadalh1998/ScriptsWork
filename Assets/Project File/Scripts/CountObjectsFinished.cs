using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountObjectsFinished : MonoBehaviour
{
    public int index;
    [ReadOnly] public bool Finsihed;
    public static bool FinishedNumbers;
    
   
    void Start()
    {
        
        Finsihed = false;
        FinishedNumbers = false;
        
    }
    

    void Update()
    {
        if (this.gameObject.transform.childCount==index  && Finsihed == false)
        {
            Finsihed = true;
            FinishedNumbers = true;
            
            print("U Win bro ...");
           // print("This Draw Finished Numbers is Your Selected");
        }
    }
   
    
}
