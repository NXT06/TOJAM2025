using NodeCanvas.Tasks.Actions;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeskBehavior : MonoBehaviour
{
    [SerializeField] public static bool isOccupied;

    public LayerMask seatLayer = -1;

    public static LayerMask currentLayer; 

    public static Collider[] seats;
    
    public static List<bool> seatStatus = new List<bool>();

    private void Awake()
    {
        currentLayer = seatLayer; 
    }
    private void Start()
    {
        seatStatus.Clear();
    }
    public static void findSeats()
    {
        //scans the area for the chosen targetLayer
        seats = Physics.OverlapSphere(Vector3.zero, 500, currentLayer);


        foreach (Collider seat in seats)
        {
           
            seatStatus.Add(true);
            Debug.Log(seatStatus.Count);
        }
    }
    public static Transform CheckOccupied(int seatIndex)
    {
        
        
        
      /*  for (int i = 0; i < seats.Length;)
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
      */

        if (seatStatus[seatIndex] == true)
        {
            seatStatus[seatIndex] = false;
            return seats[seatIndex].transform;

        }
        else { return null; }

       

        }


    

}
