using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public int lives = 3;
    public Sprite sprite1, sprite2, sprite3, sprite4;
    public Image life1, life2, life3;
    private IEnumerator coroutine;
    public int spriteFrame = 0;
    public bool animating = true;
    public float t;
    public float timer = 0.3f;
    public bool couroutineFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        //life1 = GetComponent<Image>();
        //life2 = GetComponent<Image>();
        //life3 = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 3)
        {
            life1.sprite = sprite1;
            life2.sprite = sprite1;
            life3.sprite = sprite1;
        }
        if (lives == 2)
        {
            if (animating)
            {
                coroutine = AnimationCouroutine(life3);
                StartCoroutine(coroutine);
                animating = false;
                
                //animate(life3);

            }
        }
        if (lives == 1)
        {
            if (animating)
            {
                coroutine = AnimationCouroutine(life2);
                StartCoroutine(coroutine);
                animating = false;
            }
        }
        if (lives == 0)
        {
            if (animating)
            {
                coroutine = AnimationCouroutine(life1);
                StartCoroutine(coroutine);
                animating = false;
            }
        }
    }

    void animate(Image spriteRef)
    {
        Debug.Log("Starting animation");
        //StartCoroutine(coroutine);
        if (couroutineFinished)
        {
            switch (spriteFrame)
            {
                case 0:
                    //StopCoroutine(coroutine);
                    t = 0;
                    spriteRef.sprite = sprite1;
                    animating = true;
                    couroutineFinished = false;
                    Debug.Log("Case 0");
                    //StartCoroutine(coroutine);
                    break;
                case 1:
                    t = 0;
                    spriteRef.sprite = sprite2;
                    animating = true;
                    couroutineFinished = false;
                    Debug.Log("Case 1");
                    //StartCoroutine(coroutine);
                    break;
                case 2:
                    t = 0;
                    spriteRef.sprite = sprite3;
                    animating = true;
                    couroutineFinished = false;
                    Debug.Log("Case 2");
                    //StartCoroutine(coroutine);
                    break;
                case 3:
                    StopCoroutine(coroutine);
                    t = 0;
                    animating = false;
                    couroutineFinished = false;
                    Debug.Log("Case 3");
                    spriteRef.sprite = sprite4;
                    spriteFrame = 0;
                    break;
                default:
                    break;
            }
        }
    }

    private IEnumerator AnimationCouroutine(Image spriteRef)
    {
        t = 0;
        while (t < timer)
        {
            t += Time.deltaTime;
            yield return null;
        }
        spriteFrame++;
        couroutineFinished = true;
        animate(spriteRef);
    }

    public void hit()
    {
        animating = true;
        lives--;
    }
}
