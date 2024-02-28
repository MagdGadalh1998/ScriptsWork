using UnityEngine ;
using EasyUI.PickerWheelUI ;
using UnityEngine.UI ;
using System.Collections;
using DG.Tweening;

public partial class Demo : MonoBehaviour {

    [Header("Q1 Variables")]
    [SerializeField] private Button uiSpinButton;
    [SerializeField] private PickerWheel pickerWheel;

    int player1Score = 0;
    int player2Score = 0;
    
    private void Start ()
    {
        uiSpinButton.onClick.AddListener (() => { PlayerTern();}) ;
    }
   void PlayerTern()
   {
        //ToPalyerCoin
        uiSpinButton.interactable = false;
            
        pickerWheel.OnSpinEnd(wheelPiece =>
        {
            player1Score += wheelPiece.Amount;
            print("player 1 Score = " + wheelPiece.Amount);
            StartCoroutine(ComouterTern());
        });
        StartSpain();
   }

    void StartSpain()
    {
        if (true) { pickerWheel.Spin(); }
    }
    IEnumerator ComouterTern()
    {
        //ToComputerCoin
        yield return new WaitForSeconds(1);
        pickerWheel.Spin();
        pickerWheel.OnSpinEnd(wheelPiece =>
        {
            player2Score += wheelPiece.Amount;
            print("player 2 Score = " + wheelPiece.Amount);
            uiSpinButton.interactable = true;
        });
    }
   private void Update() 
   {
        

   }
    
    
  
}