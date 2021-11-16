    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
 
    public class GameController : MonoBehaviour
    {
        public GameObject gameOver;
         public GameObject gameOverPS;
         public GameObject Pause;
         public float score;
        public Text scoreText;
        public Text  DeathTextScore;

         private player player;

        // Start is called before the first frame update
        void Start()
        {
         player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();   
        }

        // Update is called once per frame
        void Update()
        {
            if(!player.isDead){
            score += Time.deltaTime * 10f;
            scoreText.text = Mathf.Round(score).ToString();
            DeathTextScore.text = Mathf.Round(score).ToString();
            }
        }


        public void ShowGameOver(){
           gameOverPS.SetActive(false);
           Pause.SetActive(false);
            gameOver.SetActive(true);

        }

        public void RestartGame(){
            Pause.SetActive(false);
        }

        public void PauseGame(){
               Pause.SetActive(true);
               Time.timeScale = 0;
        }

        public void ReturnGame(){
                Pause.SetActive(false);
               Time.timeScale = 1;
        }
    }
