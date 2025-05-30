using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class RoomSpawnerScript : MonoBehaviour
{
    public List<GameObject> roomList = new List<GameObject>();
    private List<Vector3> roomCoordinatesList = new List<Vector3>();
    public List<Material> materialList = new List<Material>();
    public List<WallScript> wallsList = new List<WallScript>();
    public GameObject wallPrefab;
    public AudioClip fallingsfx;
    private AudioSource audiosource;
    public List<int> usedRoomsList = new List<int>();
    public AnimationCurve fallingAnimation;
    public GameObject Camera;
    public GameObject ParticleSpawner;


    public void StartLevel()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        audiosource.Play();
        createRoomCoordList();
        usedRoomsList.Add(0);
        while (usedRoomsList.Count < 9)
        {
            int rand = (int)Random.Range(1, 9);
            if (NoUsedRooms(rand))
            {
                usedRoomsList.Add(rand);
            }
        }
        StartCoroutine(RoomSpawnDelay());
        StartCoroutine(PlayWallLandSound());
        foreach (WallScript w in wallsList)
        {
            w.StartWalls();
        }
    }
   

    public IEnumerator RoomSpawnDelay()
    {
        SpawnCenterBlock();
        yield return new WaitForSeconds(1f);
        int count = 1;
        while (count < 9)
        {
            for (count = 1; count < 9; count++)
            {
                GameObject room = Instantiate(roomList[usedRoomsList[count]]);
                Vector3 upperPosition = roomCoordinatesList[count];
                upperPosition.y = 100;
                room.transform.position = upperPosition;
                StartCoroutine(RoomSpawning(room, roomCoordinatesList[count], true));
                yield return new WaitForSeconds(0.15f);

            }
        }
    }
    public IEnumerator RoomSpawning(GameObject spawnedRoom, Vector3 endPos, bool isWall)
    {

        Vector3 StartPos = spawnedRoom.transform.position;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 0.5f;
            spawnedRoom.transform.position = Vector3.Lerp(StartPos, endPos, fallingAnimation.Evaluate(t));
            if (t > 1)
            {
                StartCoroutine(RoomLanded(spawnedRoom, isWall));
            }
            yield return null;
        }

    }
    public void makeObjFall(GameObject spawnedRoom, Vector3 endPos, bool isWall)
    {
        StartCoroutine( RoomSpawning(spawnedRoom, endPos, isWall));
    }
    public bool NoUsedRooms(int rand)
    {
        foreach (int i in usedRoomsList)
        {
            if (rand == i)
            {
                return false;
            }
        }
        return true;
    }

    private void SpawnCenterBlock()
    {
        GameObject room = Instantiate(roomList[0]);
        Vector3 upperPosition = roomCoordinatesList[0];
        upperPosition.y = 50;
        room.transform.position = upperPosition;
        StartCoroutine(RoomSpawning(room, roomCoordinatesList[0], true));
    }

    public IEnumerator RoomLanded(GameObject obj, bool isWall)
    {
        
        float t = 0;
        Vector3 OGCamPos = Camera.transform.position;
        GameObject spawnedParticleSpawner = Instantiate(ParticleSpawner);
        spawnedParticleSpawner.transform.position = obj.transform.position;
        //print("Spawner created at coords | x:" + obj.transform.position.x + ", y: " + obj.transform.position.y + ", z: " + obj.transform.position.z);
        if (isWall)
        {
            audiosource.PlayOneShot(fallingsfx);
            while (t < 0.15f)
            {
                Vector3 shake = Vector3.one * sineAmount(t);
                Camera.transform.position = OGCamPos + shake;
                t += Time.deltaTime;
                yield return null;
            }
        } else
        {
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(spawnedParticleSpawner);
        Camera.transform.position = OGCamPos;
    }

    public IEnumerator PlayWallLandSound()
    {
        float t = 0;
        while (t < 4.95f)
        {
            t += Time.deltaTime;
            yield return null;
        }
        audiosource.PlayOneShot(fallingsfx);
 
    }

    private float sineAmount(float t)
    {
        return Mathf.Sin(t * 6 / 0.15f) * 0.1f;
    }

    private void createRoomCoordList()
    {
        roomCoordinatesList.Add(new Vector3(10, -0.5f, 10));
        roomCoordinatesList.Add(new Vector3(0, -0.5f, 0));
        roomCoordinatesList.Add(new Vector3(0, -0.5f, 10));
        roomCoordinatesList.Add(new Vector3(0, -0.5f, 20));
        roomCoordinatesList.Add(new Vector3(10, -0.5f, 20));
        roomCoordinatesList.Add(new Vector3(20, -0.5f, 20));
        roomCoordinatesList.Add(new Vector3(20, -0.5f, 10));
        roomCoordinatesList.Add(new Vector3(20, -0.5f, 0));
        roomCoordinatesList.Add(new Vector3(10, -0.5f, 0));
    }
    
}
