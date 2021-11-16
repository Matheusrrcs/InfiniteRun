using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
          gc= FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(){
        SceneManager.LoadScene("Game");
        gc.ReturnGame();
        Time.timeScale = 1;
    }

    public void  Quit(){
          Application.Quit();
    }
   
   public void Menu(){
        SceneManager.LoadScene("Menu");
          Time.timeScale = 1;
   }

   public void Pause(){
 gc.PauseGame();
   
   }

public void Return(){
    gc.ReturnGame();
}

}
