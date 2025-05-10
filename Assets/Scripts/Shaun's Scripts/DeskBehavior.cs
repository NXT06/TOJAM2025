using NodeCanvas.Tasks.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskBehavior : MonoBehaviour
{
    [SerializeField] public static bool isOccupied;
  

    
    public static bool CheckOccupied()
    {    
        if (isOccupied) return false;
        else return true;
    }

}
