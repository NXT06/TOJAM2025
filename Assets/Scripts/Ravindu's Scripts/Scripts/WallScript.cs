using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(falling() );
        meshRenderer = GetComponent<MeshRenderer>();
        ChooseMat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator falling()
    {
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
        meshRenderer.materials.SetValue(roomSpawner.materialList[mat1], 1);
        meshRenderer.materials.SetValue(roomSpawner.materialList[mat2], 2);
    }

    /*public void rotateWallRightAngle()
    {
        transform.Rotate(0, 90, 0);
    }*/
}
