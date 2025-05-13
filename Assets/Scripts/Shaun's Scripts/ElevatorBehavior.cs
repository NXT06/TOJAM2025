using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehavior : MonoBehaviour
{
    public GameObject DoorL;
    public GameObject DoorR;

    public float openSpeed;

    Vector3 startingPosR;
    Vector3 startingPosL;

    Vector3 endingPosR;
    Vector3 endingPosL;

    public Vector3 moveDist;
    private float moveDistanceL;
    private float moveDistanceR;
    private float startTime;
    bool doorStatus;
    bool isDoorOpen = false;




    [Range(1, 2)]
    public int doorSection = 1;

    bool isMoving;

    private void Start()
    {
        startTime = 0;
        startingPosL = Vector3.zero;
        startingPosR = Vector3.right;




    }

    public void Update()
    {
        moveDoors();

        if (!isMoving)
        {
            if (GameManager.elevatorOpen )
            {
                print("startBehavior"); 
                isMoving = true;
                startTime = 0;
                if (doorStatus)
                {

                      doorStatus = false;
                }
                if (!doorStatus)
                {
                    doorStatus = true;
                }
            }
        }


    }

    private void moveDoors()
    {

        if (!doorStatus) return;



        if (isMoving && !isDoorOpen)
        {
            print(startingPosL);
            startTime += Time.deltaTime * openSpeed;
            DoorL.transform.localPosition = Vector3.Lerp(startingPosL, Vector3.left, startTime);
            DoorR.transform.localPosition = Vector3.Lerp(startingPosR, Vector3.right * 2, startTime);


            if (startTime > 1)
            {
                isMoving = false;
                isDoorOpen = true;
            }
        }
        else if (isMoving && isDoorOpen)
        {
            startTime += Time.deltaTime * openSpeed;
            DoorL.transform.localPosition = Vector3.Lerp(Vector3.left, startingPosL, startTime);
            DoorR.transform.localPosition = Vector3.Lerp(Vector3.right * 2, startingPosR, startTime);


            if (startTime > 1)
            {
                isMoving = false;
                isDoorOpen = false;
            }
        }






    }





}
