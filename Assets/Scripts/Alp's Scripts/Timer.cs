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
    // Start is called before the first frame update
    void Start()
    {
        time = 540;
        timePeriod = "AM";
    }

    // Update is called once per frame
    void Update()
    {

        //Starts counting time
        if (minutes < 17)
        {
            time += Time.deltaTime * 50;
        }
        Debug.Log(Time.deltaTime);
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
            minutes-=12;
            timePeriod = "PM";
        }
        text.text = minute0 + minutes + ":" + second0 + seconds + " " + timePeriod;
    }
}