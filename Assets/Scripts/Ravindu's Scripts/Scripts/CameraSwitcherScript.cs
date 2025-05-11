using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcherScript : MonoBehaviour
{
    public bool inMenuCam = true;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
