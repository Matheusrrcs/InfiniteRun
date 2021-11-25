using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{


    public float gravity;
    public float speed;
    public float jumpHeight; 
    public float jumpMax;
    public float rayRadius;
    public bool isDead;
    public float laneDistance = 4;// Distancia entre duas pistas
    public float maxSpeed;

    public LayerMask layer;
    public Animator anime;
    private CharacterController controller;
    private GameController gc;

    private int desiredLane = 1; //-2:left 0: middle 2:righ
    private float jumpVelocity;
    private bool isSliding = false;
   
    void Start()
    {
        controller = GetComponent<CharacterController>();
        gc = FindObjectOfType<GameController>();
        anime = FindObjectOfType<Animator>();
    }

    void Update()
    {
        Vector3 direction = Vector3.forward * speed;

        OnColission();

   // verifica se player está no chão para ativar o pulo
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            { 
                anime.SetFloat("JumpSpeed", speed / jumpHeight);
                anime.SetBool("Jumping", true);
                jumpVelocity = jumpHeight;
                direction.z = 5 * Time.deltaTime;

            }
            else
            {
          
                anime.SetBool("Jumping", false);

            }
        }
        else
        {
            jumpVelocity -= gravity;


        }

//condição pra slider
if(Input.GetKeyDown(KeyCode.DownArrow) && !isSliding){
    StartCoroutine(Slide());
}


    //aumenta speed
      if(speed < maxSpeed){
      speed += 0.1f * Time.deltaTime; 

      }
      
      if(jumpHeight < jumpMax){
          jumpHeight += 0.1f * Time.deltaTime;
      }
        


        direction.y = jumpVelocity;

        if(!isDead){ 
        controller.Move(direction * Time.deltaTime);
    }
        //reune a informação sobre a pista em que devemos estar

        if (Input.GetKeyDown(KeyCode.RightArrow) && !isDead)
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isDead)
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }



        //caluando onde vai estar no futuro

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;


        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 10 * Time.deltaTime);



    }



    private IEnumerator Slide(){

        isSliding = true;
        anime.SetBool("isSliding",true);
        controller.center = new Vector3(0,-0.52f,0);
        controller.height = 1;
         rayRadius = 0.5f;

   
        yield return new WaitForSeconds(1.15f);

        controller.center = new Vector3(0,0.27f,0);
        controller.height = 2.56f;
        anime.SetBool("isSliding",false);
          rayRadius = 2;
        isSliding = false;

    }
 
    void OnColission()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayRadius, layer) && !isDead)
        {

            anime.SetTrigger("die");

            speed = 0;
            jumpHeight = 0;
            Invoke("GameOver", 1.5f);


            isDead = true;
        }

    }

    void GameOver()
    {
        gc.ShowGameOver();
    }

}