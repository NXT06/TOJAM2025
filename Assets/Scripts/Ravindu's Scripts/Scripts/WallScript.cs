using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class WallScript : MonoBehaviour
{
    public RoomSpawnerScript roomSpawner;
    public GameObject firstWall;
    public GameObject secondWall;
    public GameObject DoorLeft;
    public GameObject DoorRight;
    public AnimationCurve fallingCurve;
    public int mat1;
    public int mat2;
    public MeshRenderer meshRendererFirstWall;
    public MeshRenderer meshRendererSecondWall;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(falling() );
        meshRendererFirstWall = firstWall.GetComponent<MeshRenderer>();
        meshRendererSecondWall = secondWall.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator falling()
    {
        yield return new WaitForSeconds(2.15f);
        ChooseMat();
        float t = 0;
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos;
        endPos.y = 1.58548355e-05f;
        while (t < 1)
        {
            transform.position = Vector3.Lerp(startPos, endPos, fallingCurve.Evaluate(t));
            t += Time.deltaTime;
            yield return null;
        }
    }

    public void ChooseMat()
    {
        if(DoorLeft == null)
        {
            Material[] materials;

            materials = meshRendererFirstWall.materials;
            materials[1] = roomSpawner.materialList[mat1];
            meshRendererFirstWall.materials = materials;

            materials = meshRendererSecondWall.materials;
            materials[0] = roomSpawner.materialList[roomSpawner.usedRoomsList[mat2]];
            meshRendererFirstWall.materials = materials;
        } else
        {
            Material[] materials;

            materials = meshRendererFirstWall.materials;
            materials[1] = roomSpawner.materialList[roomSpawner.usedRoomsList[mat1]];
            meshRendererFirstWall.materials = materials;

            materials = meshRendererSecondWall.materials;
            materials[1] = roomSpawner.materialList[roomSpawner.usedRoomsList[mat2]];
            meshRendererFirstWall.materials = materials;

        }
    }

    /*public void rotateWallRightAngle()
    {
        transform.Rotate(0, 90, 0);
    }*/
}
