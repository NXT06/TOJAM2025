using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public static bool isGameStarted = false;

    public float doorSwitchTime = 10f;

    public Transform elevatorSpawn;
    public GameObject coworkerPrefab; 
    public GameObject coworkerPrefab2;
    public GameObject coworkerPrefab3;

    public GameObject playerPrefab; 
    public CanvasGroup canvas; 
    public float coworkerSpawnTime; 

    int currentDoorIndex; 

    public void startGame()
    {
        currentDoorIndex = DoorManager.currentDoorSection;

        StartCoroutine(SwitchDoors()); 
        StartCoroutine(spawnCoworker());
        StartCoroutine(initializeGame());
        
        
        
        
        
    }

    // Update is called once per frame
    private IEnumerator hideUI()
    {
        while (canvas.alpha > 0)
        {
            canvas.alpha -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
            print(canvas.alpha);
        }
        if(canvas.alpha <= 0)
        {
            yield return null;
        }


    }
    private IEnumerator initializeGame()
    {
        StartCoroutine(hideUI());
        yield return new WaitForSeconds(5);
        Instantiate(playerPrefab, elevatorSpawn.position, transform.rotation, null);
        isGameStarted = true;
        DeskBehavior.findSeats();





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
