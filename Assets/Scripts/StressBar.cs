using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressBar : MonoBehaviour {

    //AudioSource barAudio = GetComponent<BarAudio>();
    //GameObject vignette = GetComponent.Find("Vignette");
    //GameObject scaryHands = GetComponent.Find("ScaryHands");
    //GameObject gameOver = GetComponent.Find("GameOver");

    int currValue = 0;
    int checkpoint = 0;

	void increment () { //assume que evento falhou
        currValue += 15;
	    if (currValue >= 25 && currValue < 50) {
            //vignette.SetActive(true);
            checkpoint = 25;
        } else if (currValue >= 50 && currValue < 75) {
            //barAudio.Play();
            //trocar sprites para scared (animations & idle) mais tarde?
            checkpoint = 50;
        } else if (currValue >= 75 && currValue < 100) {
            //scaryHands.SetActive(true);
            checkpoint = 75;
        } else if (currValue >= 100) {  //checkar este primeiro? tanto faz?
            //gameOver.setActive(true);
        }
	}
	
	void decrement () { //asusume que eventou foi bem sucedido
        currValue -= 10;
        switch (checkpoint) {
            case 25:
                if (currValue<25) { currValue = 25; }
                break;
            case 50:
                if (currValue < 50) { currValue = 50; }
                break;
            case 75:
                if (currValue < 75) { currValue = 75; }
                break;
            default:
                break;
        }
    }
}
