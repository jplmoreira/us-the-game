using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClick : MonoBehaviour {

    public int speed = 5;
    public LayerMask obstacles;
    private Vector2 targetPosition;
	
	// Update is called once per frame
	void Update () {
        Vector2 pos = transform.position;
        float y = pos.y;
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Vector2 targetPos;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 relativePos = new Vector2(mousePos.x, y);
            Vector2 dir = mousePos - pos;
            RaycastHit2D hit = Physics2D.Raycast(pos, dir, 1000, obstacles);
            if (hit.collider != null) {
                targetPos = hit.point;
            } else {
                targetPos = relativePos;
            }
            transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
        }
	}
}
