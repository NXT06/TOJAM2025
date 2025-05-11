using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public GameObject DoorL;
    public GameObject DoorR;
    

    Vector3 startingPosR;
    Vector3 startingPosL;

    Vector3 endingPosR;
    Vector3 endingPosL;

    public Vector3 moveDist;
    private float moveDistanceL;
    private float moveDistanceR;
    private float startTime; 
    bool doorStatus = true; 
    public float travelSpeed;

    [Range(1, 2)]
    public int doorSection; 

    private void Start()
    {
        startingPosL = DoorL.transform.localPosition;
        startingPosR = DoorR.transform.localPosition;
        endingPosL = Vector3.left;
        endingPosL = Vector3.right * 2;

        startTime = Time.time;

        moveDistanceL = Vector3.Distance(startingPosL, endingPosL);
        moveDistanceR = Vector3.Distance(startingPosR, endingPosR);


        //print(startingPosL); 
        //print(endingPosL);
        //print(endingPosR);

    }

    public void Update()
    {
        if (doorSection ==  DoorManager.currentDoorSection && doorStatus)
        {
           // print("opening"); 
            openDoor();
            doorStatus = false;
            
        }
        if (doorSection != DoorManager.currentDoorSection && !doorStatus)
        {
            closeDoor();
            //print("closing"); 
            doorStatus = true;
            
        }
        
    }


    public void openDoor()
    {
        StartCoroutine(moveDoors(true));
    }
    public void closeDoor()
    {
        StartCoroutine (moveDoors(false));
    }

    private IEnumerator moveDoors(bool openOrclose)
    {
        float distCovered = 0;
        float fractionOfJourneyL = 0;
        float fractionOfJourneyR = 0; 
        
        if (openOrclose)
        {
             
            while (DoorR.transform.localPosition != Vector3.right * 2 || DoorL.transform.localPosition != Vector3.left)
            {
                distCovered += (Time.deltaTime - startTime) * travelSpeed;

                fractionOfJourneyL = distCovered / moveDistanceL;
                fractionOfJourneyR = distCovered / moveDistanceR;
                //print("openingDoor");

                DoorL.transform.localPosition = Vector3.Lerp(Vector3.zero, Vector3.left, fractionOfJourneyL);
                DoorR.transform.localPosition = Vector3.Lerp(Vector3.right, Vector3.right * 2, fractionOfJourneyR);
                //print(fractionOfJourneyR);
                yield return new WaitForEndOfFrame();
                //DoorR.transform.position = Vector3.Lerp(DoorR.transform.position, endingPosR, travelSpeed * Time.deltaTime);
                //DoorL.transform.position = Vector3.Lerp(DoorL.transform.position, endingPosL, travelSpeed * Time.deltaTime);
            }
        }
        if (!openOrclose)
        {
            
            while (DoorR.transform.localPosition != Vector3.right || DoorL.transform.localPosition != Vector3.zero)
            {
                //print("closingDoor");
                distCovered += (Time.deltaTime - startTime) * travelSpeed;

                fractionOfJourneyL = distCovered / moveDistanceL;
                fractionOfJourneyR = distCovered / moveDistanceR;

                DoorL.transform.localPosition = Vector3.Lerp(Vector3.left, Vector3.zero, fractionOfJourneyL);
                DoorR.transform.localPosition = Vector3.Lerp(Vector3.right * 2, Vector3.right, fractionOfJourneyR);
                yield return new WaitForEndOfFrame();
                //DoorR.transform.position = Vector3.Lerp(DoorR.transform.position, endingPosR, travelSpeed * Time.deltaTime);
                //DoorL.transform.position = Vector3.Lerp(DoorL.transform.position, endingPosL, travelSpeed * Time.deltaTime);
            }


        }

    }
}
