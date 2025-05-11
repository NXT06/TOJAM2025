using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float time;
    int seconds, minutes;
    string minute0, second0;
    string timePeriod;
    bool stop = false;
    //private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        time = 540;
        timePeriod = "AM";
        //coroutine = Timer(2.0f);
        //StartCoroutine(coroutine);
        print("Coroutine started");
    }

    // Update is called once per frame
    void Update()
    {

        //Starts counting time
        if (!stop)
        {
            time += Time.deltaTime;
        }
        //Debug.Log(Time.deltaTime);
        //Sets float to int and divides by 60 for minutes
        minutes = Mathf.FloorToInt(time / 60);
        //Minuses seconds by minutes so that it resets back to 0 everytime a minute is added
        seconds = Mathf.FloorToInt(time) - minutes * 60;
        //Set text in UI
        //text.text = "Timer: " + minutes + "m " + seconds + "s";
        if (seconds >= 10)
        {
            second0 = "";
        }
        else
        {
            second0 = "0";
        }
        if (minutes >= 10)
        {
            minute0 = "";
        }
        else
        {
            minute0 = "0";
        }
        if (minutes > 12)
        {
            time = time / (60 * 6);
            //minutes-=12;
            minutes = 2;
            timePeriod = "PM";
        }
        if (minutes == 5)
        {
            stop = true;
        }
        text.text = minute0 + minutes + ":" + second0 + seconds + " " + timePeriod;
    }

    /*private IEnumerator Timer(float waitTime)
    {
        yield return new Timer(waitTime);
        print("Coroutine ended: " + Time.time + " seconds");
    }*/
}