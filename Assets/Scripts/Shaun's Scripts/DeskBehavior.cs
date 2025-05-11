using NodeCanvas.Tasks.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskBehavior : MonoBehaviour
{
    [SerializeField] public static bool isOccupied;

    public LayerMask seatLayer = -1;

    public static Collider[] seats;
    
    public static List<bool> seatStatus = new List<bool>();

    private void Awake()
    {
        //scans the area for the chosen targetLayer
        seats = Physics.OverlapSphere(transform.position, 500, seatLayer);


        foreach (Collider seat in seats)
        {
           
            seatStatus.Add(true);
            Debug.Log(seat);
        }
    }
    public static Transform CheckOccupied()
    {
        Transform seatTransform = null; 
        
        for (int i = 0; i < seats.Length;)
        {

            if (seatStatus[i] == true)
            {
                seatStatus[i] = false;
                seatTransform = seats[i].transform;
                i = seats.Length;
            }
            else
            {
                i++; 
            }

        }

        return seatTransform; 

        }


    

}
