using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


//TUTORIAL - https://www.youtube.com/watch?v=JivuXdrIHK0



public class PauseMenu : MonoBehaviour {

    public static bool gameIsPaused = false;
    
    public GameObject pauseMenuUI;
    
    //public GameObject audioManager = GameObject.Find("AudioManager");
    

    
    //Update- check is space was pressed
    void Update(){
        
        
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("space key was pressed- pause");
           
            if(gameIsPaused){
                Resume();
                //audioManager.Resume();
            }else{
                Pause();
                //audioManager.Pause();
            }
            
        }
        
    }
	
    public void Resume(){
        
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    
    void Pause(){
        
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
  
	
    public void Options(){
        
        Debug.Log("options");
        
    }
    
    public void HomeMenu(){
        
        Debug.Log("homeMenu");
        
        Time.timeScale = 1f;

        SceneManager.LoadScene("Home Menu");
        
    }
    
    public void QuitGame(){
        
        Debug.Log("quitgame");
        
        Application.Quit();
        
    }
}
