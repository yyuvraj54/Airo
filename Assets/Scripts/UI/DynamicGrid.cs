using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicGrid : MonoBehaviour
{
   [SerializeField]
    private int rows = 5;
    [SerializeField]
    private int cols =8;
   [SerializeField]    
   private float  tileSize = 1; 
   
    void Start()
    {
        GenerateGrid();
    }

  
    private void GenerateGrid(){
         GameObject refrenceTile = (GameObject) Instantiate(Resources.Load("Prefabs/ImageView"));
        for(int i=0; i<rows; i++){
            for(int j=0; j<cols; j++){
                GameObject tile = (GameObject)Instantiate(refrenceTile,transform);
                float posX = cols * tileSize;
                float posY = rows * -tileSize;

                tile.transform.position = new Vector3(posX, posY, 0f);
                Debug.Log("Created");
            }
        }

        Destroy(refrenceTile);
        float gridW = cols *tileSize;
        float gridH = rows *tileSize;
        transform.position = new Vector3(gridW/2+tileSize/2, gridH/2 -tileSize/2, 0f);

    }   
   
}
