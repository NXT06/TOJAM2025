using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class RoomSpawnerScript : MonoBehaviour
{
    public List<GameObject> roomList = new List<GameObject>();
    private List<Vector3> roomCoordinatesList = new List<Vector3>();
    //private List<Vector3> wallCoordinatesList = new List<Vector3>();
    public List<WallScript> wallScripts = new List<WallScript>();
    public List<Material> materialList = new List<Material>();
    public GameObject wallPrefab;
    public AudioClip fallingsfx;
    private AudioSource audiosource;
    public List<int> usedRoomsList = new List<int>();
    public AnimationCurve fallingAnimation;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        createRoomCoordList();
        //createWallCoordList();
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

    }

    // Update is called once per frame
    void Update()
    {

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
            if (t > 1 && isWall)
            {
                StartCoroutine(RoomLanded());
            }
            yield return null;
        }

    }
    /*
    public IEnumerator WallSpawner()
    {
        int i = 0;
        while (i < 24)
        {
            foreach (Vector3 j in wallCoordinatesList)
            {
                i++;
                GameObject spawnedWall = Instantiate(wallPrefab);
                WallScript wallScript = spawnedWall.GetComponent<WallScript>();
                Vector3 Upperposition = j;
                Upperposition.y = 100;
                spawnedWall.transform.position = Upperposition;
                if (i == 2 || (i > 3 && i < 6) || (i > 7 && i < 11) || (i > 13 && i < 17) || (i > 21))
                {
                    wallScript.rotateWallRightAngle();
                }
                StartCoroutine(RoomSpawning(spawnedWall, j, false));
            }
        }
        yield return null;
    }*/



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

    public IEnumerator RoomLanded()
    {
        audiosource.PlayOneShot(fallingsfx);
        float t = 0;
        Vector3 OGCamPos = Camera.transform.position;

        while (t < 0.15f)
        {
            Vector3 shake = Vector3.one * sineAmount(t);
            Camera.transform.position = OGCamPos + shake;
            t += Time.deltaTime;
            yield return null;
        }
        Camera.transform.position = OGCamPos;

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
    /*
    private void createWallCoordList()
    {
        wallCoordinatesList.Add(new Vector3(4.82999992f, 1.5854841e-05f, 12.0200005f)); //1
        wallCoordinatesList.Add(new Vector3(11.969986f, 1.58548355e-05f, 15.140192f));//2
        wallCoordinatesList.Add(new Vector3(14.8299122f, 1.58548355e-05f, 11.9999943f));//3
        wallCoordinatesList.Add(new Vector3(11.969986f, 1.58548355e-05f, 5.14019203f));//4
        wallCoordinatesList.Add(new Vector3(2, 1.58548355e-05f, 5.13000011f));//5
        wallCoordinatesList.Add(new Vector3(-5.14008617f, 1.58548355e-05f, 11.9999943f));//6
        wallCoordinatesList.Add(new Vector3(-5.14008522f, 1.58548355e-05f, 21.9999924f));//7
        wallCoordinatesList.Add(new Vector3(1.75000095f, 1.58548355e-05f, 24.8599205f));//8
        wallCoordinatesList.Add(new Vector3(11.7500038f, 1.58548355e-05f, 24.8599205f));//9
        wallCoordinatesList.Add(new Vector3(21.75f, 1.58548355e-05f, 24.8599205f));//10
        wallCoordinatesList.Add(new Vector3(24.8599129f, 1.58548355e-05f, 21.9999924f));//11
        wallCoordinatesList.Add(new Vector3(24.8599129f, 1.58548355e-05f, 11.9999943f));//12
        wallCoordinatesList.Add(new Vector3(24.8599129f, 1.58548355e-05f, 1.95000005f));//13     1.58548355e-05f
        wallCoordinatesList.Add(new Vector3(21.8999977f, 1.58548355e-05f, -5.14008045f));//14
        wallCoordinatesList.Add(new Vector3(11.8999996f, 1.58548355e-05f, -5.14008045f));//15
        wallCoordinatesList.Add(new Vector3(1.89999866f, 1.58548355e-05f, -5.14008045f));//16
        wallCoordinatesList.Add(new Vector3(-5.14008522f, 1.58548355e-05f, 1.99999237f));//17
        wallCoordinatesList.Add(new Vector3(4.82000017f, 1.58548355e-05f, 1.88f));//18 edited
        wallCoordinatesList.Add(new Vector3(4.85991287f, 1.58548355e-05f, 21.9999924f));//19
        wallCoordinatesList.Add(new Vector3(14.8599138f, 1.58548355e-05f, 21.9999943f));//20
        wallCoordinatesList.Add(new Vector3(14.8500004f, 1.58548355e-05f, 1.97000003f));//21 edited
        wallCoordinatesList.Add(new Vector3(21.8500004f, 1.58548355e-05f, 5.11000013f));//22
        wallCoordinatesList.Add(new Vector3(21.8999996f, 1.58548355e-05f, 15.1300001f));//23
        wallCoordinatesList.Add(new Vector3(1.83999991f, 1.58548355e-05f, 15.1400003f));//24



    }*/
}
