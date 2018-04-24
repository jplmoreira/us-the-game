using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//https://www.youtube.com/watch?v=zc8ac_qUXQY     TUTORIAL

public class MainMenu : MonoBehaviour {

	public void PlayGame(){
        //SceneManager.GetActiveScene().buildIndex()+1
        SceneManager.LoadScene("Protoype");
    }
    
    public void OptionsMenu(){
        
    }
    
}
