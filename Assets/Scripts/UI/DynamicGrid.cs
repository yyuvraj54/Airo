using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicGrid : MonoBehaviour
{
   [SerializeField] private int rows = 5;
    [SerializeField] private int cols =8;
   [SerializeField] private float  tileSize = 1; 
    
    [SerializeField] private GameObject imageViewPrefab;
   
    void Start()
    {
        GenerateGrid();
    }

  
    private void GenerateGrid(){
           GameObject referenceTile = Instantiate(imageViewPrefab);
        for(int i=0; i<rows; i++){
            for(int j=0; j<cols; j++){
                GameObject tile = Instantiate(referenceTile, transform);

                float posX = j * tileSize; // Fixed calculation for X position
                float posY = -i * tileSize; // Invert the row index for Y position


                tile.transform.position = new Vector3(posX, posY, 0f);
                Debug.Log("Created");
            }
        }

        Destroy(referenceTile);
        float gridW = 200;
        float gridH = 200;
        transform.position = new Vector3(gridW, gridH, 0f);

    }   
   
}
