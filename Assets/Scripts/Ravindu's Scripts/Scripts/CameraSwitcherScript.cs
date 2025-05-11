using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcherScript : MonoBehaviour
{
    public bool inMenuCam = true;
    public Animator animator;

    public void SwitchStates()
    {
        if (inMenuCam)
        {
            animator.Play("GameCam");
        } else
        {
            animator.Play("MenuCam");
        }
        inMenuCam = !inMenuCam;
    }
}
