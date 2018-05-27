using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable {

    public Transform resPos;

    public void Interact_WalkThrough() {
        Transform currP = CharacterSwap.ins.currP.transform;
        currP.position = resPos.position;
        currP.GetComponent<PointClick>().StopMoving();
        currP.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
