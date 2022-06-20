using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsAnimationScript : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("ShouldSpin", false);
        Debug.Log(animator.gameObject);
    }

}
