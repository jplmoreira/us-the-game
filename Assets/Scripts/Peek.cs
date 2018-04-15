using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peek : MonoBehaviour {

    public float lookAheadFactor;
    public float moveRate;

    private Vector2 truePos;
    private Vector2 targetPos;
    private bool move = false;
    private bool buttonDown = false;
    private float z;

	// Use this for initialization
	void Awake () {
        truePos = transform.position;
        z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Mouse2) && !move) {
            buttonDown = true;
            GetComponent<Follow>().Focus(false);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = mousePos - (Vector2) transform.position;
            dir.Normalize();
            targetPos = mousePos + dir * lookAheadFactor;
            truePos = transform.position;
            move = true;
        } else if (Input.GetKeyUp(KeyCode.Mouse2)) {
            buttonDown = false;
            GetComponent<Follow>().Focus(false);
            targetPos = truePos;
            move = true;
        }
        if (move) {
            Vector2 newPos = Vector2.Lerp(truePos, targetPos, Time.deltaTime * 1);
            transform.position = new Vector3(newPos.x, newPos.y, z);
            if (Vector2.Distance(transform.position, targetPos) < 0.01) {
                move = false;
                if (!buttonDown)
                    GetComponent<Follow>().Focus(true);
            }
        }
    }
}
