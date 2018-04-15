﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClick : MonoBehaviour {

    public int speed = 5;
    public LayerMask obstacles;
    private Vector2 targetPosition;
    private bool move = false;
    Animator animator;
    
    // Initializing animation
    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        Vector2 pos = transform.position;
        float y = pos.y;

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            move = true;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 relativePos = new Vector2(mousePos.x, y);
            Vector2 dir = relativePos - pos;

            if (dir.x < 0 && transform.localScale.x > 0 || dir.x > 0 && transform.localScale.x < 0) {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }

            float distance = Vector2.Distance(pos, relativePos);
            RaycastHit2D hit = Physics2D.Raycast(pos, dir, distance, obstacles);

            if (hit.collider != null) {
                targetPosition = hit.point;
            } else {
                targetPosition = relativePos;
            }
        }

        if (move) {
            animator.SetBool("Walking", true);
            transform.position = Vector2.MoveTowards(pos, targetPosition, Time.deltaTime * speed);
            if (Vector2.Distance(pos, targetPosition) < 0.01) {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                animator.SetBool("Walking", false);
                move = false;
                
            }
        }    
    }
}
