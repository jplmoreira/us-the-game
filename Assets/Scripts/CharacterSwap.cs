using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwap : MonoBehaviour {

    GameObject[] characters;
    GameObject currChar;
    GameObject swapScreen;

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
    [HideInInspector]
    public IIventoryItem currItem;
    
    
    public AudioManager audioManager;

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

    private void Start() {
        Inventory.ins.ItemSelected += SelectItem;
    }

    public void swapChuck() {
        DeselectItem(currItem);
        swapScreen = GameObject.Find("CharacterSwap");
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
            CharSwap(this, new CharacterSwapArgs(currNum));
        }
        swapScreen.GetComponent<WalkieTalkie>().charSwap();
    }
    public void swapNewt() {
        DeselectItem(currItem);
        swapScreen = GameObject.Find("CharacterSwap");
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
            CharSwap(this, new CharacterSwapArgs(currNum));
        }
        swapScreen.GetComponent<WalkieTalkie>().charSwap();
    }
    public void swapPiper() {
        DeselectItem(currItem);
        swapScreen = GameObject.Find("CharacterSwap");
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
            CharSwap(this, new CharacterSwapArgs(currNum));
        }
        swapScreen.GetComponent<WalkieTalkie>().charSwap();
    }
    public void swapWesley() {
        DeselectItem(currItem);
        swapScreen = GameObject.Find("CharacterSwap");
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
            CharSwap(this, new CharacterSwapArgs(currNum));
        }
        swapScreen.GetComponent<WalkieTalkie>().charSwap();
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

    void SelectItem(object sender, InventoryEventArgs e) {
        IIventoryItem item = e.Item;
        GameObject hand = GameObject.FindWithTag("Hand");
        if (hand != null) {
            DeselectItem(item);
            if (item.Equals(currItem))
                return;
            GameObject goItem = (item as MonoBehaviour).gameObject;
            goItem.transform.parent = hand.transform;
            goItem.transform.position = hand.transform.position;
            goItem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            goItem.SetActive(true);
            currItem = item;
        }
    }

    public void DeselectItem(IIventoryItem item) {
        if (item != null && item.Equals(currItem)) {
            currItem.OnUse();
            GameObject goItem = (currItem as MonoBehaviour).gameObject;
            goItem.transform.parent = null;
            goItem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            goItem.SetActive(false);
            currItem = null;
        }
        audioManager.Stop("AimSlingshot");
    }
}

public class CharacterSwapArgs : EventArgs {
	public CharacterSwapArgs(int charNum) {
		Num = charNum;
	}

	public int Num;
}