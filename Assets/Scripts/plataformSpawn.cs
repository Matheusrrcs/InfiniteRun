using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformSpawn : MonoBehaviour
{
     public GameObject[] plataformPrefabs;
     public float zSpawn = 0;
     public float plataformLength = 86;
     public int numberOfPlataforms = 3;
     private List<GameObject> activePlataform = new List<GameObject>();

     public Transform playerTransform;

    void Start()
    {
        for(int i = 0; i < numberOfPlataforms; i++){

            SpawnPlataform(i);
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z- 91 > zSpawn - (numberOfPlataforms * plataformLength)){
            SpawnPlataform(Random.Range(0,plataformPrefabs.Length));
             DeletPlataform();
        }
    }


    public void SpawnPlataform(int plataformIndex){

         GameObject go = Instantiate(plataformPrefabs[plataformIndex], transform.forward * zSpawn, transform.rotation);
          activePlataform.Add(go);
         zSpawn += plataformLength;
    }

    private void DeletPlataform(){
        Destroy(activePlataform[0]);
        activePlataform.RemoveAt(0);
    }
}
