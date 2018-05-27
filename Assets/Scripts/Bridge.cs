using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : Interactable {

    bool opened = false;

    public GameObject hole;

	public void Interact_Push() {
        if (CharacterSwap.ins.currP.name.Contains("Player4")) {
            if (!opened) {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<Animator>().SetBool("opened", true);
                hole.SetActive(false);
                opened = true;
            }
        } else
            DialogueManager.ins.NewDialogue("I am not strong enough to push this!");
    }
}
