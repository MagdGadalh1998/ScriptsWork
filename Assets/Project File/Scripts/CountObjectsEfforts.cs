using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CountObjectsEfforts : MonoBehaviour
{
    public int index;
    [ReadOnly] public bool Finsihed;
    [ReadOnly] public bool Finsihed1;

    public static bool EffortNumbers;

    [Header("Lifes")]
    public GameObject Wrong1;
    public GameObject Wrong2;
    public GameObject Right1;
    public GameObject Right2;
    [Space]
    public GameObject happy;
    public GameObject sad;   
    void Start()
    {
        Finsihed = false;
        Finsihed1 = false;
        EffortNumbers = false;
    }

    void Update()
    {
       /* if (this.gameObject.transform.childCount==1&&Finsihed1 == false)
        {
            Finsihed1 = true;
            LifesHandller();
            print("Lose 1");
        }
        else */if (this.gameObject.transform.childCount ==index && Finsihed == false)
        {
            Finsihed = true;
            EffortNumbers = true;
            /*LifesHandller();*/
            print("Lose 2");
            print("This Effort Numbers is Your Selected");
        }
    }
    /*void LifesHandller()
    {
        if (!Wrong1.activeSelf)
        {
            Wrong1.SetActive(true);
            Right1.SetActive(false);
        }
        //lose 2
        else
        {
            Wrong2.SetActive(true);
            sad.SetActive(true);
            happy.SetActive(false);
            Right2.SetActive(false);
            StartCoroutine(NextScene());
        }
    }*/
   /* IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }*/
}
