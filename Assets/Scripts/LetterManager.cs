using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SpriteRenderer letterSpriteRenderer,fillRenderer;
    [SerializeField] SpriteMask letterSpriteMask;
    void Awake()
    {
        letterSpriteMask.sprite= letterSpriteRenderer.sprite;
        GetComponent<SpriteRenderer>().enabled = false;
        //ColorManager.singleton.onColorChange.AddListener(ChangeColor);
    }

    public void ChangeColor()
    {
        fillRenderer.color = ColorManager.currentColor;
    }
    private void OnDestroy()
    {
        //ColorManager.singleton.onColorChange.RemoveListener(ChangeColor);
    }
}
