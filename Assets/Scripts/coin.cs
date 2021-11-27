using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private GameController gc;
    
  public List<GameObject> plataforms =  new List<GameObject>();
   
    // Start is called before the first frame update
    void Start()
    {
         
         gc= FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other) {

        if(other.tag == "Player"){
           GameController.numberOfCoins += 1;
            
            Destroy(gameObject);
        }}
}
