using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedColorController : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
        transform.parent.parent.GetComponentInChildren<TraceCurve.TraceInput>().OnShapeFinish.AddListener(ActivateAnimatior);
    }

    public void ActivateAnimatior()
    {
        animator.enabled = true;
    }
}
