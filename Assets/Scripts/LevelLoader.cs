using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



// https://www.youtube.com/watch?v=YMj2qPq9CP8    TUTORIAL

public class LevelLoader : MonoBehaviour {

    
    public GameObject loadingScreen;
    
    public Slider slider;
    
    public Text progressText;
        
        
    public void LoadLevel(int sceneIndex){
        
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    
    
    IEnumerator LoadAsynchronously (int sceneIndex){
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        
        loadingScreen.SetActive(true);
        
        while(!operation.isDone){
            
            float progress = Mathf.Clamp01(operation.progress/ .9f);
            
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            
            yield return null;
        }
    }
}
