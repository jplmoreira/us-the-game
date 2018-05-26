using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public static DialogueManager ins;
    private Animator animator;

    public Text diaName;
    public Text dialogue;
    public Image portrait;

    public Sprite p1;
    public Sprite p2;
    public Sprite p3;
    public Sprite p4;

    void Awake() {
        ins = this;
        GameObject dialogueBox = GameObject.FindGameObjectWithTag("DialogueBox");
        if (!dialogueBox) {
            Debug.LogError("Could not find dialogue box");
            return;
        }
        animator = dialogueBox.GetComponent<Animator>();
    }

    public void NewDialogue(string message) {
        SwapCharInfo();
        dialogue.text = message;
        animator.SetBool("opened", true);
        StartCoroutine(EndDialogue());
    }

    void SwapCharInfo() {
        string name = CharacterSwap.ins.currP.name;
        if (name.Contains("Player1")) {
            diaName.text = "Wesley";
            portrait.sprite = p1;
        } else if (name.Contains("Player2")) {
            diaName.text = "Newt";
            portrait.sprite = p2;
        } else if (name.Contains("Player3")) {
            diaName.text = "Piper";
            portrait.sprite = p3;
        } else if (name.Contains("Player4")) {
            diaName.text = "Chuck";
            portrait.sprite = p4;
        } else {
            Debug.LogError("Different name than expected: " + name);
        }
    }

    IEnumerator EndDialogue() {
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("opened", false);
    }
}
