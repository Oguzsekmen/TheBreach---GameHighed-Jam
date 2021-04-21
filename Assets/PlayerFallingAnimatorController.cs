using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingAnimatorController : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenParachute()
    {
        animator.SetTrigger("OpenParachute");
    }

    public void Land()
    {
        animator.SetTrigger("Land");
    }
}
