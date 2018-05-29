using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour {

    public Transform resPos;
    public GameObject door;

	public void Yes() {
        CharacterSwap.ins.currP.transform.position = resPos.position;
        CharacterSwap.ins.currP.GetComponent<PointClick>().StopMoving();
        CharacterSwap.ins.currP.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        CharacterSwap.ins.ChangePosition(resPos.position);
        gameObject.SetActive(false);
        StressBar.ins.zero();
    }

    public void No() {
        door.GetComponent<Animator>().SetBool("opened", false);
        door.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.SetActive(false);
    }
}
