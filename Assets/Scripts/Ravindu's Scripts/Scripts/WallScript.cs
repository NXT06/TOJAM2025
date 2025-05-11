using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class WallScript : MonoBehaviour
{
    public RoomSpawnerScript roomSpawner;
    public bool isExtWall;
    public GameObject firstWall;
    public GameObject secondWall;
    public GameObject DoorLeft;
    public GameObject DoorRight;
    public AnimationCurve fallingCurve;
    public int mat1;
    public int mat2;
    private MeshRenderer meshRendererFirstWall;
    private MeshRenderer meshRendererSecondWall;
    // Start is called before the first frame update
    void Start()
    {
        meshRendererFirstWall = firstWall.GetComponent<MeshRenderer>();
        meshRendererSecondWall = secondWall.GetComponent<MeshRenderer>();
        StartCoroutine(falling());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator falling()
    {
        yield return new WaitForSeconds(2.95f);
        ChooseMat();
        print(transform.position.y);
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos;

        endPos.y -= 100.13353f;
        roomSpawner.makeObjFall(gameObject, endPos, false);
        /*while (t < 1)
        {
            t += Time.deltaTime *0.5f;
            print(startPos);
            print(endPos);
            print(t);
            transform.position = Vector3.Lerp(startPos, endPos, fallingCurve.Evaluate(t));
            yield return null;
        }*/
    }

    public void ChooseMat()
    {
        if (isExtWall)
        {
            Material[] materialsSecond;

            materialsSecond = meshRendererSecondWall.materials;
            materialsSecond[0] = roomSpawner.materialList[roomSpawner.usedRoomsList[mat2]];
            meshRendererSecondWall.materials = materialsSecond;
        }
        if (!isExtWall)
        {
            Material[] materialsFirst;

            materialsFirst = meshRendererFirstWall.materials;
            materialsFirst[1] = roomSpawner.materialList[roomSpawner.usedRoomsList[mat1]];
            meshRendererFirstWall.materials = materialsFirst;

            Material[] materialsSecond;

            materialsSecond = meshRendererSecondWall.materials;
            materialsSecond[1] = roomSpawner.materialList[roomSpawner.usedRoomsList[mat2]];
            meshRendererSecondWall.materials = materialsSecond;

        }
    }

    /*public void rotateWallRightAngle()
    {
        transform.Rotate(0, 90, 0);
    }*/
}
