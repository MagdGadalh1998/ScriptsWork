using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class L9GameMAnager : MonoBehaviour {


    public GameObject Puzzle1, Puzzle2, Puzzle3, Puzzle4, Puzzle1Block, Puzzle2Block, Puzzle3Block, Puzzle4Block;

    public GameObject Brk,Mskn,Khlan,Asmak,winCanvas;
    public GameObject Hand;
    public bool Check_1,Check_2, Check_3, Check_4;

   
    public AudioClip celebrateSound;
    public AudioClip celebrateSound_1;


    Vector3 initialPuzzle1Position, initialPuzzle2Position, initialPuzzle3Position, initialPuzzle4Position;



    public Text scoretext;
    int Score = 0;
    [SerializeField] AudioClip Winsound;
    




    void Start()
    {
        initialPuzzle1Position = Puzzle1.transform.position;
        initialPuzzle2Position = Puzzle2.transform.position;
        initialPuzzle3Position = Puzzle3.transform.position;
        initialPuzzle4Position = Puzzle4.transform.position;

        Check_1 = false;
        Check_2 = false;
        Check_3 = false;
        Check_4 = false;


    }





    public void DragPuzzle1()
    {

        //Puzzle1.transform.position = Input.mousePosition;

        Puzzle1.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }


    public void DragPuzzle2()
    {

       
        Puzzle2.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)); 

    }

    public void DragPuzzle3()
    {

       
        Puzzle3.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)); 

    }
 
    public void DragPuzzle4()
    {

       
        Puzzle4.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)); 

    }

    





    


    public void DropPuzzle1()
    {

        float distance = Vector3.Distance(Puzzle1.transform.position, Puzzle1Block.transform.position);
        Debug.Log(distance);
        if (distance < 90.00040)
        {
            Puzzle1.transform.position = Puzzle1Block.transform.position;
            if (Check_1 == false)
            {
                StartCoroutine(HideBrk());
            }


        }
        else

        {
            Puzzle1.transform.position = initialPuzzle1Position;
            
        }




    }

    public void DropPuzzle2()
    {

        float distance = Vector3.Distance(Puzzle2.transform.position, Puzzle2Block.transform.position);
        if (distance < 90.00040)
        {
            Puzzle2.transform.position = Puzzle2Block.transform.position;
            if (Check_2 == false)
            {
                StartCoroutine(HideMskn());
            }
        }

        else
        {
            Puzzle2.transform.position = initialPuzzle2Position;

        }

    }

    public void DropPuzzle3()
    {

        float distance = Vector3.Distance(Puzzle3.transform.position, Puzzle3Block.transform.position);
        if (distance < 90.00040)
        {
            Puzzle3.transform.position = Puzzle3Block.transform.position;
            if (Check_3 == false)
            {
                StartCoroutine(HideKhlan());
            }

        }
        else
        {
            Puzzle3.transform.position = initialPuzzle3Position;
           
        }

    }


    public void DropPuzzle4()
    {

        float distance = Vector3.Distance(Puzzle4.transform.position, Puzzle4Block.transform.position);
        if (distance < 90.00040)
        {
            Puzzle4.transform.position = Puzzle4Block.transform.position;
            Puzzle4.transform.localScale = Puzzle4Block.transform.localScale;
            if (Check_4 == false)
            {
                StartCoroutine(WinCanvas());
            }

        }
        else
        {
            Puzzle4.transform.position = initialPuzzle4Position;
            
        }
    }

    IEnumerator HideBrk()
    {
        Check_1 = true;
        AudioSource.PlayClipAtPoint(Winsound, new Vector2(0, 0));
        AddPoint();
        yield return new WaitForSeconds(0.1f);
        Puzzle1.gameObject.GetComponent<Image>().raycastTarget = false;
        yield return new WaitForSeconds(2);
        Brk.SetActive(false);
        Hand.SetActive(false);
        yield return new WaitForSeconds(2);
        Mskn.SetActive(true);

    }
    IEnumerator HideMskn()
    {
        Check_2 = true;
        AudioSource.PlayClipAtPoint(Winsound, new Vector2(0, 0));
        AddPoint();
        yield return new WaitForSeconds(0.1f);
        Puzzle2.gameObject.GetComponent<Image>().raycastTarget = false;
        yield return new WaitForSeconds(2);
        Mskn.SetActive(false);
        Hand.SetActive(false);
        yield return new WaitForSeconds(2);
        Khlan.SetActive(true);

    }
    IEnumerator HideKhlan()
    {
        Check_3 = true;
        AudioSource.PlayClipAtPoint(Winsound, new Vector2(0, 0));
        AddPoint();
        yield return new WaitForSeconds(0.1f);
        Puzzle3.gameObject.GetComponent<Image>().raycastTarget = false;
        yield return new WaitForSeconds(2);
        Khlan.SetActive(false);
        Hand.SetActive(false);
        yield return new WaitForSeconds(2);
        Asmak.SetActive(true);

    }
    IEnumerator WinCanvas()
    {
        Check_4 = true;
        AudioSource.PlayClipAtPoint(Winsound, new Vector2(0, 0));
        AddPoint();
        yield return new WaitForSeconds(0.1f);
        Puzzle4.gameObject.GetComponent<Image>().raycastTarget = false;
        yield return new WaitForSeconds(3);
        winCanvas.SetActive(true);
        AudioSource.PlayClipAtPoint(celebrateSound, new Vector2(0, 0));
        AudioSource.PlayClipAtPoint(celebrateSound_1, new Vector2(0, 0));
    }

    public void AddPoint()
    {
        Score += 10;
        scoretext.text = Score.ToString();
    }

}
