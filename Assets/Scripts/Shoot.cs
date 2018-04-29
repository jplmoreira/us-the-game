using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject stone;
    public float shootCD;
    public float bulletForce;

    float time;

    private void Start() {
        time = 0;
    }

    // Update is called once per frame
    void FixedUpdate () {
        time += Time.deltaTime;
        if (time >= shootCD && Input.GetButtonDown("Fire1")) {
            time = 0;
            Vector3 pos = new Vector3(transform.position.x + 0.05f, transform.position.y + 0.1f, transform.position.z);
            Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.parent.position;
            dir.Normalize();
            GameObject go = Instantiate(stone, pos, transform.parent.rotation);
            go.GetComponent<Rigidbody2D>().AddForce(dir * bulletForce, ForceMode2D.Impulse);
        }
	}
}
