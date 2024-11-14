using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    [SerializeField] Transform runnersParent;

    public void Run()
    {
        for(int i = 0; i < runnersParent.childCount; i++)
        {
            Transform runner = runnersParent.GetChild(i);
            Animator animator = runner.GetComponent<Animator>();

            animator.Play("Run");
        }
    }

    public void Idle()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            Transform runner = runnersParent.GetChild(i);
            Animator animator = runner.GetComponent<Animator>();

            animator.Play("Idle");
        }
    }
}
