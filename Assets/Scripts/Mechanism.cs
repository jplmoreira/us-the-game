using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanism : Interactable {

    int state = -1;

    public Transform m1l;
    public Transform m1r;
    public Transform m2l;
    public Transform m2r;

    public Transform m1;
    public Transform m2;

    public GameObject door1;
    public GameObject door2;

    public void Interact_Interact() {
        switch (state) {
            case -1:
                if (CharacterSwap.ins.currP.name.Contains("Player2")) {
                    if (CharacterSwap.ins.currItem != null && CharacterSwap.ins.currItem.Name == "Lever") {
                        IIventoryItem item = CharacterSwap.ins.currItem;
                        CharacterSwap.ins.DeselectItem(item);
                        Inventory.ins.RemoveItem(item);
                        GameObject goItem = (item as MonoBehaviour).gameObject;
                        Destroy(goItem);
                        GetComponent<Animator>().SetTrigger("active");
                        transform.localScale = new Vector3(1f, 1f, 1f);
                        door1.SetActive(true);
                        door2.SetActive(true);
                        state = 0;
                    } else
                        DialogueManager.ins.NewDialogue("It seems to fit some kind of mechanism...");
                } else
                    DialogueManager.ins.NewDialogue("I can't seem to figure this out...");
                break;
            case 0:
                int player1 = CharacterSwap.ins.CharacterBetween(m1l.position.x, m1r.position.x);
                if (player1 >= 0) {
                    CharacterSwap.ins.ChangePosition(player1, m2.position);
                    GetComponent<Animator>().SetBool("down", true);
                    door1.GetComponent<Animator>().SetBool("down", true);
                    door2.GetComponent<Animator>().SetBool("down", true);
                    state = 1;
                } else
                    DialogueManager.ins.NewDialogue("The mechanism seems to work with only one person on it...");
                break;
            case 1:
                int player2 = CharacterSwap.ins.CharacterBetween(m2l.position.x, m2r.position.x);
                if (player2 >= 0) {
                    CharacterSwap.ins.ChangePosition(player2, m1.position);
                    GetComponent<Animator>().SetBool("down", false);
                    door1.GetComponent<Animator>().SetBool("down", false);
                    door2.GetComponent<Animator>().SetBool("down", false);
                    state = 0;
                } else
                    DialogueManager.ins.NewDialogue("The mechanism seems to work with only one person on it...");
                break;
            default:
                Debug.LogError("Error in mechanism state!");
                return;
        }
    }
}
