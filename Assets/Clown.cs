using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown : Climbable {

    public Transform pushPos;

    public void Interact_Interact() {
        Animator anim = GetComponent<Animator>();
        if (anim != null) {
            anim.SetBool("Opened", !anim.GetBool("Opened"));
        }
    }

    public void Interact_Push() {
        if (CharacterSwap.ins.currP.transform.name.Contains("Player4"))
            if (!transform.position.Equals(pushPos))
                transform.position = pushPos.position;
    }
}
