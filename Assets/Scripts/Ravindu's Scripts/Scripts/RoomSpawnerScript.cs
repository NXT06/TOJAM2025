using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomSpawnerScript : MonoBehaviour
{
    public List<GameObject> roomList = new List<GameObject>();
    private List<Vector3> roomCoordinatesList = new List<Vector3>();
    private List<int> usedRoomsList = new List<int>();
    public AnimationCurve fallingAnimation;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i += 10)
        {
            for (int j = 0; j < 30; j += 10)
            {
                print(roomCoordinatesList);
                roomCoordinatesList.Add(new Vector3(i, -0.5f, j));
            }
        }
        while (usedRoomsList.Count < 8)
        {
            int rand = Random.Range(1, 9);
            if (NoUsedRooms(rand))
            {
                usedRoomsList.Add(rand);
            }
        }
        Coroutine StartRoomSpawning = StartCoroutine(RoomSpawnDelay());

    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator RoomSpawnDelay()
    {
        SpawnCenterBlock();
        yield return new WaitForSeconds(0.25f);
        int count = 0;
        while (count < 9)
        {
            foreach (int i in usedRoomsList)
            {
                GameObject room = Instantiate(roomList[i]);
                Vector3 upperPosition = roomCoordinatesList[count];
                upperPosition.y = 50;
                print("////" + upperPosition);
                room.transform.position = upperPosition;
                StartCoroutine(RoomSpawning(room, roomCoordinatesList[count]));
                count++;
                if (count == 4)
                {
                    count++;
                }
                yield return new WaitForSeconds(0.25f);

            }
        }
    }
    public IEnumerator RoomSpawning(GameObject spawnedRoom, Vector3 endPos)
    {

        print("room pos at start: " + spawnedRoom.transform.position + "   |end pos for room: " + endPos);
        print("Coroutine started");
        Vector3 StartPos = spawnedRoom.transform.position;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 0.5f;
            print(t);
            spawnedRoom.transform.position = Vector3.Lerp(StartPos, endPos, fallingAnimation.Evaluate(t));
            if (t > 1)
            {
                RoomLanded();
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
        //spawning center block
        GameObject room = Instantiate(roomList[0]);
        Vector3 upperPosition = roomCoordinatesList[4];
        upperPosition.y = 50;
        print("////" + upperPosition);
        room.transform.position = upperPosition;
        StartCoroutine(RoomSpawning(room, roomCoordinatesList[4]));
    }

    public void RoomLanded()
    {

    }
}
