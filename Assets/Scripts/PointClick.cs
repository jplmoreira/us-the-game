using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClick : MonoBehaviour {

    public int speed;
    Animator animator;
    private float targetX;
    private Rigidbody2D rb;
    private Vector2 lastPos;
    private float timePassed = 0f;
    private Vector2 dir = Vector2.right;
    [HideInInspector]
    public bool interacting;
    
    // Initializing animation
    void Start() {
        interacting = false;
        lastPos = transform.position;
        targetX = transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.constraints |= RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update() {
        if (!interacting) {
            if (Input.GetKey(KeyCode.Mouse1)) {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (mousePos.x - transform.position.x < 0 && transform.localScale.x > 0 ||
                    mousePos.x - transform.position.x > 0 && transform.localScale.x < 0) {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    dir = new Vector2(dir.x * -1, 0);
                }
                targetX = mousePos.x;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (!interacting) {
            float dis = Mathf.Abs(targetX - transform.position.x);
            if (dis < 0.15) {
                StopMoving();
            } else if (Mathf.Abs(rb.velocity.x) <= speed) {
                rb.AddForce(dir * 1000, ForceMode2D.Force);
            }
        }
        if (timePassed > 0.5f) {
            if (lastPos.x == transform.position.x)
                StopMoving();
            else
                lastPos = transform.position;
            timePassed = 0f;
        }
        timePassed += Time.deltaTime;
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }

    public void StopMoving() {
        targetX = transform.position.x;
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
}
