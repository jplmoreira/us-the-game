using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbable : Interactable {

    public Transform climbPos;
	
    public void Interact_Climb() {
        Transform currP = CharacterSwap.ins.currP.transform;
		if (currP.name.Contains ("Player1")) {

			currP.position = climbPos.position;
			currP.GetComponent<PointClick> ().StopMoving ();
			currP.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		} else
			DialogueManager.ins.NewDialogue ("I'm not agile enough to climb this!\nMaybe Wesley could climb it...");
    }
}
