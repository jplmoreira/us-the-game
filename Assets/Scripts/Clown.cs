﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown : Climbable {

    public Transform pushPos;
    bool scared = false;
    bool pushed = false;

    public void Interact_Interact() {
        Animator anim = GetComponent<Animator>();
        if (anim != null) {
            anim.SetBool("Opened", !anim.GetBool("Opened"));
        }
        if (!scared) {
            StressBar.ins.increment(40);
            scared = true;
        }
    }

    public void Interact_Push() {
        if (CharacterSwap.ins.currP.transform.name.Contains("Player4") && !pushed) {
            pushed = true;
            transform.position = pushPos.position;
        }
    }
}