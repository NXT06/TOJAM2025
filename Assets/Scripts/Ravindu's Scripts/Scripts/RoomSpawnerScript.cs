using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class RoomSpawnerScript : MonoBehaviour
{
    public List<GameObject> roomList = new List<GameObject>();
    private List<Vector3> roomCoordinatesList = new List<Vector3>();
    private List<Vector3> wallCoordinatesList = new List<Vector3>();
    public List<Material> materialList = new List<Material>();
    public GameObject wallPrefab;
    public AudioClip fallingsfx;
    private AudioSource audiosource;
    private List<int> usedRoomsList = new List<int>();
    public AnimationCurve fallingAnimation;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        createRoomCoordList();
        while (usedRoomsList.Count < 8)
        {
            int rand = Random.Range(1, 9);
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
                GameObject room = Instantiate(roomList[usedRoomsList[count - 1]]);
                Vector3 upperPosition = roomCoordinatesList[count];
                upperPosition.y = 50;
                room.transform.position = upperPosition;
                StartCoroutine(RoomSpawning(room, roomCoordinatesList[count]));
                yield return new WaitForSeconds(0.15f);

            }
        }
        StartCoroutine(WallSpawner());
    }
    public IEnumerator RoomSpawning(GameObject spawnedRoom, Vector3 endPos)
    {

        Vector3 StartPos = spawnedRoom.transform.position;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 0.5f;
            spawnedRoom.transform.position = Vector3.Lerp(StartPos, endPos, fallingAnimation.Evaluate(t));
            if (t > 1)
            {
                StartCoroutine(RoomLanded());
            }
            yield return null;
        }

    }

    public IEnumerator WallSpawner()
    {
        int i = 0;
        while (i < 24)
        {
            foreach(Vector3 j in roomCoordinatesList)
            {
                i++;
                GameObject spawnedWall = Instantiate(wallPrefab);
                WallScript wallScript = spawnedWall.GetComponent<WallScript>();
            }
        }
        yield return null;
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
        StartCoroutine(RoomSpawning(room, roomCoordinatesList[0]));
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
        return Mathf.Sin(t * 6 / 0.15f) * 0.2f;
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

    private void createWallCoordList()
    {
        wallCoordinatesList.Add(new Vector3(4.82999992f, 1.5854841e-05f, 12.0200005f));
        wallCoordinatesList.Add(new Vector3(11.969986f, 1.58548355e-05f, 15.140192f));
        wallCoordinatesList.Add(new Vector3(14.8299122f, 1.58548355e-05f, 11.9999943f));
        wallCoordinatesList.Add(new Vector3(11.969986f, 1.58548355e-05f, 5.14019203f));
        wallCoordinatesList.Add(new Vector3(-1.99999523f, 1.58548355e-05f, 4.85991859f));
        wallCoordinatesList.Add(new Vector3(-5.14008617f, 1.58548355e-05f, 11.9999943f));
        wallCoordinatesList.Add(new Vector3(-5.14008522f, 1.58548355e-05f, 21.9999924f));
        wallCoordinatesList.Add(new Vector3(-1.99999523f, 1.58548355e-05f, 24.8599205f));
        wallCoordinatesList.Add(new Vector3(8.00000763f, 1.58548355e-05f, 24.8599205f));
        wallCoordinatesList.Add(new Vector3(18.0000038f, 1.58548355e-05f, 24.8599205f));
        wallCoordinatesList.Add(new Vector3(24.8599129f, 1.58548355e-05f, 21.9999924f));
        wallCoordinatesList.Add(new Vector3(24.8599129f, 1.58548355e-05f, 11.9999943f));
        wallCoordinatesList.Add(new Vector3(24.8599129f, 1.58548355e-05f, 11.9999943f));
        wallCoordinatesList.Add(new Vector3(18.0000038f, 1.58548355e-05f, -5.14008045f));
        wallCoordinatesList.Add(new Vector3(8.00000572f, 1.58548355e-05f, -5.14008045f));
        wallCoordinatesList.Add(new Vector3(-1.99999523f, 1.58548355e-05f, -5.14008045f));
        wallCoordinatesList.Add(new Vector3(-5.14008522f, 1.58548355e-05f, 1.99999237f));
        wallCoordinatesList.Add(new Vector3(-1.99999523f, 1.58548355e-05f, 14.8599205f));
        wallCoordinatesList.Add(new Vector3(4.85991287f, 1.58548355e-05f, 21.9999924f));
        wallCoordinatesList.Add(new Vector3(14.8599138f, 1.58548355e-05f, 21.9999943f));
        wallCoordinatesList.Add(new Vector3(18.0000038f, 1.58548355e-05f, 14.8599195f));
        wallCoordinatesList.Add(new Vector3(18.0000038f, 1.58548355e-05f, 4.85991859f));
        wallCoordinatesList.Add(new Vector3(14.8599138f, 1.58548355e-05f, 1.99999237f));
        wallCoordinatesList.Add(new Vector3(4.85991287f, 1.58548355e-05f, 1.99999237f));



    }
}
