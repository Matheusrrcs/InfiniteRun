 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlataform : MonoBehaviour
{

   public List<GameObject> plataforms =  new List<GameObject>();
   public List<Transform> currentPlatforms = new List<Transform>();

   public int offset;
   
   private Transform player;
   private Transform currentPlatformPoint;
   private int plataformIndex;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

     for (int i = 0; i< plataforms.Count; i++){

        Transform p =  Instantiate(plataforms[i], new Vector3(0,0,i * 86),transform.rotation).transform;
        currentPlatforms.Add(p);
        offset += 86;
     }

     currentPlatformPoint = currentPlatforms[plataformIndex].GetComponent<Plataform>().point;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = player.position.z - currentPlatformPoint.position.z;
    
        if(distance >= 5){
            Recycle(currentPlatforms[plataformIndex].gameObject);
            plataformIndex++;

             if(plataformIndex > currentPlatforms.Count - 1){
                plataformIndex = 0;
            }
         
        currentPlatformPoint = currentPlatforms[plataformIndex].GetComponent<Plataform>().point;    
  
        }

    }


    public void Recycle(GameObject plataform){

             plataform.transform.position = new Vector3(0,0,offset);
             offset += 86;
    }
}
