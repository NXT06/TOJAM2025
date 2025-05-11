using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public static bool isGameStarted = false;
    

    public float doorSwitchTime = 10f;

    public Transform elevatorSpawn;
    public Transform playerSpawn; 
    public GameObject menuCamera; 

    public GameObject coworkerPrefab; 
    public GameObject coworkerPrefab2;
    public GameObject coworkerPrefab3;

    public GameObject playerPrefab; 
    public CanvasGroup canvas; 
    public float coworkerSpawnTime; 

    int currentDoorIndex;

    public static bool elevatorOpen = false; 

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
            canvas.interactable = false;
            yield return new WaitForEndOfFrame();
           // print(canvas.alpha);
        }
        if(canvas.alpha <= 0)
        {
            yield return null;
        }


    }
    private IEnumerator initializeGame()
    {
        menuCamera.SetActive(false);
        StartCoroutine(hideUI());
        print("opening elevator");
        yield return new WaitForSeconds(4); 
        elevatorOpen = true;
        yield return new WaitForSeconds(5);
        
        Instantiate(playerPrefab, playerSpawn.position, transform.rotation, null);
        Instantiate(coworkerPrefab, elevatorSpawn.position, transform.rotation, null);
        isGameStarted = true;
        DeskBehavior.findSeats();
        yield return new WaitForSeconds(5);
        print("closing elevator");
        elevatorOpen = false; 





    }
    private IEnumerator spawnCoworker()
    {
        while (true)
        {
            yield return new WaitForSeconds(coworkerSpawnTime);
            elevatorOpen = true;
            print("opening elevator"); 
            int rand = Random.Range(0, 2);
            if (rand == 0)
                Instantiate(coworkerPrefab, elevatorSpawn.position, transform.rotation, null);
            else if (rand == 1)
                Instantiate(coworkerPrefab2, elevatorSpawn.position, transform.rotation, null);
            else if (rand == 2)
                Instantiate(coworkerPrefab3, elevatorSpawn.position, transform.rotation, null);
            //print("spawned");
            yield return new WaitForSeconds(5f);
            print("closing elevator");
            elevatorOpen = false;
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
