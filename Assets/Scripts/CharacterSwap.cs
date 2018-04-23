using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwap : MonoBehaviour {

    public Transform player1;
    private Vector3 pos1;
    public Transform player2;
    private Vector3 pos2;
    public Transform player3;
    private Vector3 pos3;
    public Transform player4;
    private Vector3 pos4;

    public GameObject cam;

    private int currNum;

	[HideInInspector]
	public GameObject currP;
	[HideInInspector]
	public event EventHandler<CharacterSwapArgs> CharSwap;
	[HideInInspector]
	public static CharacterSwap ins;

    private void Awake() {
		ins = this;
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");
        if (characters.Length != 1) {
            Debug.LogError("More than one character Active!");
            return;
        }
        GameObject currChar = characters[0];
		currP = currChar;
        pos1 = currChar.transform.position;
        pos2 = currChar.transform.position;
        pos3 = currChar.transform.position;
        pos4 = currChar.transform.position;
        currNum = 1;
    }

    void swapChuck() {

    }
    void swapNewt() {

    }
    void swapPiper() {

    }
    void swapWesley() {

    }
    // Update is called once per frame
    void Update () {
        GameObject[] characters;
        GameObject currChar;
	    if (Input.GetKeyDown(KeyCode.Alpha1) && currNum != 1) {
            characters = GameObject.FindGameObjectsWithTag("Character");
            if (characters.Length != 1) {
                Debug.LogError("More than one character Active!");
                return;
            }
            currChar = characters[0];
            SavePosition(currChar);
            Destroy(currChar);
            Transform aux = Instantiate(player1, pos1, Quaternion.identity);
			currP = aux.gameObject;
            currNum = 1;
            StartCoroutine(cam.GetComponent<Follow>().SwapFocus());
			if (CharSwap != null) {
				CharSwap (this, new CharacterSwapArgs (currNum));
			}
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && currNum != 2) {
            characters = GameObject.FindGameObjectsWithTag("Character");
            if (characters.Length != 1) {
                Debug.LogError("More than one character Active!");
                return;
            }
            currChar = characters[0];
            SavePosition(currChar);
            Destroy(currChar);
			Transform aux = Instantiate(player2, pos2, Quaternion.identity);
			currP = aux.gameObject;
            currNum = 2;
            StartCoroutine(cam.GetComponent<Follow>().SwapFocus());
			if (CharSwap != null) {
				CharSwap (this, new CharacterSwapArgs (currNum));
			}
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && currNum != 3) {
            characters = GameObject.FindGameObjectsWithTag("Character");
            if (characters.Length != 1) {
                Debug.LogError("More than one character Active!");
                return;
            }
            currChar = characters[0];
            SavePosition(currChar);
            Destroy(currChar);
			Transform aux = Instantiate(player3, pos3, Quaternion.identity);
			currP = aux.gameObject;
            currNum = 3;
            StartCoroutine(cam.GetComponent<Follow>().SwapFocus());
			if (CharSwap != null) {
				CharSwap (this, new CharacterSwapArgs (currNum));
			}
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && currNum != 4) {
            characters = GameObject.FindGameObjectsWithTag("Character");
            if (characters.Length != 1) {
                Debug.LogError("More than one character Active!");
                return;
            }
            currChar = characters[0];
            SavePosition(currChar);
            Destroy(currChar);
			Transform aux = Instantiate(player4, pos4, Quaternion.identity);
			currP = aux.gameObject;
            currNum = 4;
            StartCoroutine(cam.GetComponent<Follow>().SwapFocus());
			if (CharSwap != null) {
				CharSwap (this, new CharacterSwapArgs (currNum));
			}
        }
    }

    void SavePosition(GameObject character) {
        string name = character.transform.name;
        if (name.Contains("Player1")) {
            pos1 = character.transform.position;
        } else if (name.Contains("Player2")) {
            pos2 = character.transform.position;
        } else if (name.Contains("Player3")) {
            pos3 = character.transform.position;
        } else if (name.Contains("Player4")) {
            pos4 = character.transform.position;
        } else {
            Debug.LogError("Different name than expected: " + name);
        }
    }
}

public class CharacterSwapArgs : EventArgs {
	public CharacterSwapArgs(int charNum) {
		Num = charNum;
	}

	public int Num;
}