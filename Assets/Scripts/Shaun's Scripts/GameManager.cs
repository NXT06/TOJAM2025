using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float doorSwitchTime = 10f;

    int currentDoorIndex; 

    void Start()
    {
        currentDoorIndex = DoorManager.currentDoorSection;

        StartCoroutine(SwitchDoors()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SwitchDoors()
    {
        while (true)
        {
            
            
            yield return new WaitForSeconds(doorSwitchTime);
            currentDoorIndex++;
            if (currentDoorIndex > 2) currentDoorIndex = 1; 
             
            DoorManager.currentDoorSection = currentDoorIndex;
            print(currentDoorIndex);
        }


    }
}
