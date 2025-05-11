using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public GameObject firstWall;
    public GameObject secondWall;
    public GameObject DoorLeft;
    public GameObject DoorRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rotateWallRightAngle()
    {
        transform.Rotate(0, 90, 0);
    }
}
