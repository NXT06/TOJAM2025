using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    public Slider slider;
    public static float t = 20f;
    float timer = 0f;
    public float startTime; 
    

    public static bool sliderStatus = true; 
    // Start is called before the first frame update
    void Start()
    {
        t = startTime;
        slider = GetComponent<Slider>();
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator Timer()
    {
        
        while (t > timer)
        {
            t = Mathf.Clamp(t, -1, 40f);
            t -= Time.deltaTime;
            slider.value = t;
            yield return null;
        }
        if(t <= 0)
        {
            sliderStatus = false;
        }
    }
}
