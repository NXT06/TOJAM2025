using System.Collections;
using System.Collections.Generic;

using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

public class FieldOfView : MonoBehaviour 
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    public float meshResolution; 

    Blackboard blackboard;

   

    private void Start()
    {
        blackboard = GetComponent<Blackboard>();
        playerRef = GameObject.FindGameObjectWithTag("Player"); 
        StartCoroutine(FOVRoutine()); 
    }

    private IEnumerator FOVRoutine()
    {
        float delay = 0.1f; 
        WaitForSeconds wait = new WaitForSeconds(delay);
        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
            blackboard.SetVariableValue("PlayerInSight", canSeePlayer);
            
        }


    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0 )
        {
           // print("target"); 
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized; 

            if(Vector3.Angle(transform.forward,directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true; 

                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false; 
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false; 
        }
    }


}
