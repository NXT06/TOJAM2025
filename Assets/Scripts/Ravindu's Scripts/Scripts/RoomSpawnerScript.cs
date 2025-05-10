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


        roomCoordinatesList.Add(new Vector3(10, -0.5f, 10));
        roomCoordinatesList.Add(new Vector3(0, -0.5f, 0));
        roomCoordinatesList.Add(new Vector3(0, -0.5f, 10));
        roomCoordinatesList.Add(new Vector3(0, -0.5f, 20));
        roomCoordinatesList.Add(new Vector3(10, -0.5f, 20));
        roomCoordinatesList.Add(new Vector3(20, -0.5f, 20));
        roomCoordinatesList.Add(new Vector3(20, -0.5f, 10));
        roomCoordinatesList.Add(new Vector3(20, -0.5f, 0));
        roomCoordinatesList.Add(new Vector3(10, -0.5f, 0));


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
        int count=1;
        while (count <= 9)
        {
            for(count =1; count<9; count++)
            {
                GameObject room = Instantiate(roomList[usedRoomsList[count]]);
                Vector3 upperPosition = roomCoordinatesList[count];
                upperPosition.y = 50;
                room.transform.position = upperPosition;
                StartCoroutine(RoomSpawning(room, roomCoordinatesList[count]));
                yield return new WaitForSeconds(0.15f);

            }
        }
    }
    public IEnumerator RoomSpawning(GameObject spawnedRoom, Vector3 endPos)
    {
        
        Vector3 StartPos = spawnedRoom.transform.position;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 0.5f;
            print(t);
            spawnedRoom.transform.position = Vector3.Lerp(StartPos, endPos, fallingAnimation.Evaluate(t));
            if (t > 1)
            {
                StartCoroutine(RoomLanded());
            }
            yield return null;
        }

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
}
