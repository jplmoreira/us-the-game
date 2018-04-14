using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClick : MonoBehaviour {

    public int speed = 5;
    public LayerMask obstacles;
    private Vector2 targetPosition;
    private bool move = false;

    // Update is called once per frame
    void FixedUpdate () {
        Vector2 pos = transform.position;
        float y = pos.y;
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
            move = true;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 relativePos = new Vector2(mousePos.x, y);
            Vector2 dir = relativePos - pos;
            //comparar posicao do rato com posicao do click
            //mudar o sprite de acordo
            float distance = Vector2.Distance(pos, relativePos);
            RaycastHit2D hit = Physics2D.Raycast(pos, dir, distance, obstacles);
            if (hit.collider != null) {
                targetPosition = hit.point;
            } else {
                targetPosition = relativePos;
            }
        }
        if (move) {
            //activar animaçao
            transform.position = Vector2.MoveTowards(pos, targetPosition, Time.deltaTime * speed);
            if (Vector2.Distance(pos, targetPosition) < 0.01) {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                move = false;
                //voltar ao sprite normal/animaçao idle
            }
        }    
    }
}
