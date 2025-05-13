using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public static int kissCounter = 0;
    public float kissRatio;
    
    public TextMeshProUGUI text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = kissCounter.ToString();
    }

    public static void Kiss()
    {
        kissCounter++;
    }
}
