using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameOver : MonoBehaviour {
    

    public void Restart(){
        
        SceneManager.LoadScene("Demo");        
        Time.timeScale = 0f;
    }

    
    public void HomeMenu(){
        
        Debug.Log("homeMenu");
        
        Time.timeScale = 1f;

        SceneManager.LoadScene("Home Menu");
        
    }
    
    public void ExitGame(){
        
        Debug.Log("exitgame");
                
        Application.Quit();
        
    }
}
