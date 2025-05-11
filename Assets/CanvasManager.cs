using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject playCloud;
    public GameObject quitCloud;
    public GameObject Logo;
    private float t;
    private Vector3 PCpos;
    private Vector3 QCpos;
    // Start is called before the first frame update
    void Start()
    {
        PCpos = playCloud.transform.position;
        QCpos = quitCloud.transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime*0.2f;
        PCpos += Vector3.up * SinAmount(t);
        PCpos += Vector3.right * CosAmount(t);
        playCloud.transform.position = PCpos;

        QCpos += Vector3.right * SinAmount(t);
        QCpos += Vector3.up * CosAmount(t);
        quitCloud.transform.position = QCpos;
    }

    private float SinAmount(float t)
    {
        return Mathf.Sin(t)*0.0005f;
    }
    private float CosAmount(float t)
    {
        return Mathf.Cos(t) * 0.0005f;
    }
}
