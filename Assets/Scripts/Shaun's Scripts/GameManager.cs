using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float doorSwitchTime = 10f;

    public Transform elevatorSpawn;
    public GameObject coworkerPrefab; 
    public GameObject coworkerPrefab2;
    public float coworkerSpawnTime; 

    int currentDoorIndex; 

    void Start()
    {
        currentDoorIndex = DoorManager.currentDoorSection;

        StartCoroutine(SwitchDoors()); 
        StartCoroutine(spawnCoworker());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator spawnCoworker()
    {
        while (true)
        {
            yield return new WaitForSeconds(coworkerSpawnTime);
            int rand = Random.Range(0, 1);
            if (rand == 0)
                Instantiate(coworkerPrefab, elevatorSpawn.position, transform.rotation, null);
            else
                Instantiate(coworkerPrefab2, elevatorSpawn.position, transform.rotation, null);
            print("spawned");
        }

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
