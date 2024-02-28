using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFinishEffect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip [] sounds;
    [SerializeField] GameObject effectObject;
    public void Onfinish()
    {
        if (sounds != null)
        {
            AudioSource.PlayClipAtPoint(sounds[Random.Range(0,sounds.Length)], new Vector2(0, 0));
        }
        if (effectObject)
        {
            Instantiate(effectObject,transform.position, effectObject.transform.rotation);
        }
    }
}
