using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    public Slider slider;
    public float t = 20f;
    public float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void kiss()
    {
        t = 20f;
    }

    private IEnumerator Timer()
    {
        t = 20f;
        while (t > timer)
        {
            t -= Time.deltaTime;
            slider.value = t;
            yield return null;
        }
    }
}
