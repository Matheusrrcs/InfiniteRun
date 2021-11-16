    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class player : MonoBehaviour
    {

      private CharacterController controller;

      public float speed;
      public float jumpHeight;
      public float gravity;
      public float rayRadius;
      public float horizontalSpeed;
      public bool isDead; 
      
      public LayerMask layer;
      public Animator anime;

      private float jumpVelocity;
      private bool isMovingLeft;
      private bool isMovingRight;
      private GameController gc;


        // Start is called before the first frame update
        void Start()
        {
            controller = GetComponent<CharacterController>();
            gc= FindObjectOfType<GameController>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 direction = Vector3.forward * speed;
            OnColission();

            if(controller.isGrounded){

              if(Input.GetKeyDown(KeyCode.Space)){
                    jumpVelocity = jumpHeight;
                     
              }
            

              if(Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 3f && !isMovingRight && !isDead){
                isMovingRight = true;
                  StartCoroutine(RightMove());
              }
              if(Input.GetKeyDown(KeyCode.LeftArrow)&& transform.position.x > -3f && !isMovingLeft && !isDead){
                isMovingLeft = true; 
                StartCoroutine(LeftMove());
              }

        }
              else{
                  jumpVelocity -= gravity;       
              }
        direction.y = jumpVelocity;

        controller.Move(direction * Time.deltaTime);
    }

    IEnumerator LeftMove(){
        
        for(float i = 0; i < 10; i += 0.1f){
          controller.Move(Vector3.left * Time.deltaTime * horizontalSpeed);
          yield return null;
        }
      isMovingLeft = false;    
    }

    IEnumerator RightMove(){
      
      for(float i = 0; i < 10; i += 0.1f){
          controller.Move(Vector3.right * Time.deltaTime * horizontalSpeed);
          yield return null;
        }
          isMovingRight = false;

          
    }

      void OnColission(){

        RaycastHit hit; 

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayRadius, layer) && !isDead){
              
              anime.SetTrigger("die");
              
              speed = 0;
              jumpHeight = 0;
              Invoke("GameOver",1.5f);
              

              isDead = true;
        }

      }

      void GameOver(){
        gc.ShowGameOver();
      }
      
    }