using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public static bool isGameStarted = false;
    

    public float doorSwitchTime = 10f;

    public Transform elevatorSpawn;
    public Transform playerSpawn; 
    public GameObject menuCamera;
    public GameObject mapCamera; 

    public GameObject coworkerPrefab; 
    public GameObject coworkerPrefab2;
    public GameObject coworkerPrefab3;

    public GameObject playerPrefab; 
    public CanvasGroup canvas1;
    public CanvasGroup canvas2;
    public GameObject canvas2Object; 
    public float coworkerSpawnTime;

    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject endWindow; 

    int currentDoorIndex;

    public static bool elevatorOpen = false;

    public AudioSource audioFX;
    public AudioSource audioMusic;
    public AudioClip elevatorDing;

    public void startGame()
    {
        currentDoorIndex = 1; 

        StartCoroutine(SwitchDoors()); 
        StartCoroutine(spawnCoworker());
        StartCoroutine(initializeGame());
        
        audioMusic.Play();
        
        
        
        
    }
    private void Update()
    {
        if (isGameStarted)
        {


            if (!Timer.timerStatus)
            {
                print("win"); 
                EndScreen(true);
            }
            if (!Sliders.sliderStatus)
            {
                print("notime");
                EndScreen(false);
            }
            if (Lives.lives <= 0)
            {
                print("nolives"); 
                EndScreen(false);
            }
        }
    }

    public void QuitGame()
    {

        Application.Quit();
    }

    // Update is called once per frame
    private IEnumerator hideUI()
    {

        while (canvas1.alpha > 0)
        {
            canvas1.alpha -= Time.deltaTime;
            canvas1.interactable = false;
            yield return new WaitForEndOfFrame();
           // print(canvas.alpha);
        }
        if(canvas1.alpha <= 0)
        {
            yield return null;
        }


    }

    public void EndScreen(bool winLose)
    {
        isGameStarted = false;
        endWindow.SetActive(true); 
        if (winLose)
        {
            winScreen.SetActive(true);
            
        }
        else
        {
            loseScreen.SetActive(true);
        }

    }
    public void RestartGame()
    {
        Lives.lives = 3;
        Sliders.t = 40;
        Sliders.sliderStatus = true; 
        isGameStarted = false ;
        endWindow.SetActive(false);
        SceneManager.LoadScene("MainScene");

    }
    private IEnumerator showUI()
    {
        
        while (canvas2.alpha < 1)
        {
            canvas2.alpha += Time.deltaTime;
            canvas2.interactable = false;
            yield return new WaitForEndOfFrame();
            // print(canvas.alpha);
        }
        if (canvas2.alpha >= 1)
        {
            yield return null;
        }


    }
    private IEnumerator initializeGame()
    {
        menuCamera.SetActive(false);
        StartCoroutine(hideUI());
       
        audioFX.clip = elevatorDing;
        audioFX.Play();
        yield return new WaitForSeconds(4);
        canvas2Object.SetActive(true);
        StartCoroutine (showUI());
        DeskBehavior.findSeats();
        elevatorOpen = true;
        yield return new WaitForSeconds(0.1f);
        elevatorOpen = false;
        
        
        playerPrefab.SetActive(true);
        Instantiate(coworkerPrefab, elevatorSpawn.position, transform.rotation, null);
        //yield return new WaitForSeconds(1); 
        //Instantiate(coworkerPrefab, elevatorSpawn.position, transform.rotation, null);
        mapCamera.SetActive(false );
        isGameStarted = true;
        yield return new WaitForSeconds(5);
        elevatorOpen = true;
        yield return new WaitForSeconds(0.1f);
        elevatorOpen = false;
        





    }
    private IEnumerator spawnCoworker()
    {
        while (true)
        {
            yield return new WaitForSeconds(coworkerSpawnTime);
            elevatorOpen = true;
            yield return new WaitForSeconds(0.1f);
            elevatorOpen = false;
          
            audioFX.clip = elevatorDing;
            audioFX.Play();
            int rand = Random.Range(0, 4);
            if (rand < 2)
                Instantiate(coworkerPrefab, elevatorSpawn.position, transform.rotation, null);
            else if (rand < 3)
                Instantiate(coworkerPrefab2, elevatorSpawn.position, transform.rotation, null);
            else if (rand <= 4)
                Instantiate(coworkerPrefab3, elevatorSpawn.position, transform.rotation, null);
            //print("spawned");
            yield return new WaitForSeconds(5f);
            elevatorOpen = true;
            yield return new WaitForSeconds(0.1f);
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
