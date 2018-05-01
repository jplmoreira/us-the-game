using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressBar : MonoBehaviour {

    public int currentStress = 0;
    public int checkpoint = 0;
    public RectTransform stressBar;

    //AudioSource barAudio = GetComponent<BarAudio>();
    GameObject vignette = GameObject.Find("Vignette");
    //GameObject scaryHands = GetComponent.Find("ScaryHands");
    GameObject gameOver = GameObject.Find("GameOver");



	void increment (int amount) { //assume que evento falhou
        currentStress += amount;
	    if (currentStress >= 25 && currentStress < 50) {
            vignette.SetActive(true);
            checkpoint = 25;
        } else if (currentStress >= 50 && currentStress < 75) {
            //barAudio.Play();
            //trocar sprites para scared (animations & idle) mais tarde?
            checkpoint = 50;
        } else if (currentStress >= 75 && currentStress < 100) {
            //scaryHands.SetActive(true);
            checkpoint = 75;
        } else if (currentStress >= 100) {  //checkar este primeiro? tanto faz?
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
        stressBar.sizeDelta = new Vector2(currentStress, stressBar.sizeDelta.y);
    }
	
	void decrement (int amount) { //asusume que eventou foi bem sucedido
        currentStress -= amount;
        switch (checkpoint) {
            case 0:
                if (currentStress < 0) {
                    currentStress = 0;
                    stressBar.sizeDelta = new Vector2(currentStress, stressBar.sizeDelta.y);
                }
                break;
            case 25:
                if (currentStress < 25) {
                    currentStress = 25;
                    stressBar.sizeDelta = new Vector2(currentStress, stressBar.sizeDelta.y);
                }
                break;
            case 50:
                if (currentStress < 50) {
                    currentStress = 50;
                    stressBar.sizeDelta = new Vector2(currentStress, stressBar.sizeDelta.y);
                }
                break;
            case 75:
                if (currentStress < 75) {
                    currentStress = 75;
                    stressBar.sizeDelta = new Vector2(currentStress, stressBar.sizeDelta.y);
                }
                break;
            default:
                stressBar.sizeDelta = new Vector2(currentStress, stressBar.sizeDelta.y);
                break;
        }
    }
}
