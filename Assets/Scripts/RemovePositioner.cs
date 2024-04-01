using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePositioner : MonoBehaviour
{
    
    public GameObject midAirPositioner;
    public void remove()
    {
        Debug.Log("Running Destroy");
       

        // Check if the game object exists
        if (midAirPositioner != null)
        {
            // Destroy the game object
            Destroy(midAirPositioner);
        }
        else
        {
            Debug.LogWarning("Vuforia Mid Air Positioner game object not found.");
        }
    }
}