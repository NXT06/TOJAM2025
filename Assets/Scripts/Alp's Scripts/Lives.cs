using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public int lives = 3;
    public Sprite sprite;
    public Image life1, life2, life3;
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
            life1.color = new Color(255, 255, 255, 255);
            life2.color = new Color(255, 255, 255, 255);
            life3.color = new Color(255, 255, 255, 255);
        }
        if (lives == 2)
        {
            life1.color = new Color(255, 255, 255, 255);
            life2.color = new Color(255, 255, 255, 255);
            life3.color = new Color(255, 255, 255, 0);
        }
        if (lives == 1)
        {
            life1.color = new Color(255, 255, 255, 255);
            life2.color = new Color(255, 255, 255, 0);
            life3.color = new Color(255, 255, 255, 0);
        }
        if (lives == 0)
        {
            life1.color = new Color(255, 255, 255, 0);
            life2.color = new Color(255, 255, 255, 0);
            life3.color = new Color(255, 255, 255, 0);
        }
    }


}
