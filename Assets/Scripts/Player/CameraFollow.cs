using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /*public GameObject girlChar;
    public GameObject boyChar;*/

    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public float xOffset = 1f;
    
    public Vector2 minBounds;
    public Vector2 maxBounds;
    public GameObject player;
    // Update is called once per frame
    void Start()
    {
        /*if (ManageSelectPlayer.boySelected)
        {
            boyChar.SetActive(true);
            player = boyChar;
        }
        else if (ManageSelectPlayer.girlSelected)
        {
            girlChar.SetActive(true);
            player = girlChar;
        }*/
    }
    void FixedUpdate()
    {
        /*if(ManageSelectPlayer.toStart)
        {
          */  Vector3 newPos2 = new Vector3(player.GetComponent<Transform>().position.x + xOffset
                                     , player.GetComponent<Transform>().position.y + yOffset
                                     , -10f);
            // to get the bondries of the camera 
            float clampedX = Mathf.Clamp(newPos2.x, minBounds.x, maxBounds.x);
            float clampedY = Mathf.Clamp(newPos2.y, minBounds.y, maxBounds.y);
            Vector3 bonPos = new Vector3(clampedX, clampedY, transform.position.z);
            transform.position = Vector3.Slerp(bonPos, newPos2, FollowSpeed * Time.fixedDeltaTime);
        /*}*/
        
    }



}
