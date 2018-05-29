using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitDoor : Interactable {

    public GameObject initScreen;

	public void Interact_Open() {
        initScreen.SetActive(true);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Animator>().SetBool("opened", true);
    }
}
