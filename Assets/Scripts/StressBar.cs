using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class StressBar : MonoBehaviour {

    public int currentStress = 0;
    public int checkpoint = 0;
    public RectTransform stressBar;
    public static StressBar ins;

    public AudioManager audioManager;
    public GameObject vignette;
	Animator vigAnim;
    //public GameObject scaryHands = GetComponent.Find("ScaryHands");
    public GameObject gameOver;

	float width;


    IEnumerator playStressBarSoundEffect(string name){
        
        yield return new WaitForSeconds(9);
        audioManager.Play(name);
    }

    private void Awake() {
        
		ins = this;
		vigAnim = vignette.GetComponent<Animator> ();
		width = stressBar.parent.gameObject.GetComponent<RectTransform>().sizeDelta.x;
    }
    
    
    public void increment (int amount) { //assume que evento falhou
        currentStress += amount;
        
        
        if(currentStress < 10){
            
            if(audioManager.isPlayingSound() == true){
                StartCoroutine(playStressBarSoundEffect("DoorCloses"));
            }else{
                audioManager.Play("DoorCloses");
            }
            
        }else if(currentStress >= 10 && currentStress < 25){
            
            if(audioManager.isPlayingSound() == true){
                StartCoroutine(playStressBarSoundEffect("LaughWoman2"));
            }else{
                audioManager.Play("LaughWoman2");
            }
            
        }else if (currentStress >= 25 && currentStress < 50) {

            vignette.SetActive(true);
			Time.timeScale = 1f;
            checkpoint = 25;
            
            if(audioManager.isPlayingSound() == true){
                StartCoroutine(playStressBarSoundEffect("DoorSqueack"));
            }else{
                audioManager.Play("DoorSqueack");
            }
            
            
			
            
        } else if (currentStress >= 50 && currentStress < 75) {
            //trocar sprites para scared (animations & idle) mais tarde?
            audioManager.Play("LaughStepsSinging");
            checkpoint = 50;
			vigAnim.speed = 1.5f;
            
            if(audioManager.isPlayingSound() == true){
                StartCoroutine(playStressBarSoundEffect("LaughWitch"));
            }else{
                audioManager.Play("LaughWitch");
            }
            
        } else if (currentStress >= 75 && currentStress < 100) {
            //scaryHands.SetActive(true);
            checkpoint = 75;
			vigAnim.speed = 2f;
            
            if(audioManager.isPlayingSound() == true){
                StartCoroutine(playStressBarSoundEffect("Heartbeat"));
            }else{
                audioManager.Play("Heartbeat");
            }

        } else if (currentStress >= 100) {  //checkar este primeiro? tanto faz?
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
		float percent = (float) currentStress / 100f;
		stressBar.sizeDelta = new Vector2(percent*width, stressBar.sizeDelta.y);
    }
	
    
	public void decrement (int amount) { //asusume que eventou foi bem sucedido
        currentStress -= amount;
		float percent;
        switch (checkpoint) {
            case 0:
                if (currentStress < 0) {
                    currentStress = 0;
					percent = (float) currentStress / 100f;
					stressBar.sizeDelta = new Vector2(percent*width, stressBar.sizeDelta.y);
                }
                break;
            case 25:
                if (currentStress < 25) {
                    currentStress = 25;
					percent = (float) currentStress / 100f;
					stressBar.sizeDelta = new Vector2(percent*width, stressBar.sizeDelta.y);
                }
                break;
            case 50:
                if (currentStress < 50) {
                    currentStress = 50;
					percent = (float) currentStress / 100f;
					stressBar.sizeDelta = new Vector2(percent*width, stressBar.sizeDelta.y);
                }
                break;
            case 75:
                if (currentStress < 75) {
                    currentStress = 75;
					percent = (float) currentStress / 100f;
					stressBar.sizeDelta = new Vector2(percent*width, stressBar.sizeDelta.y);
                }
                break;
            default:
				percent = (float) currentStress / 100f;
				stressBar.sizeDelta = new Vector2((currentStress/100)*width, stressBar.sizeDelta.y);
                break;
        }
    }
}
