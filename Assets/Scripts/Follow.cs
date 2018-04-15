using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    private GameObject player;       //Public variable to store a reference to the player game object
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    private bool focus = true;

    private void Awake() {
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");
        if (characters.Length != 1) {
            Debug.LogError("More than one character Active!");
            return;
        }
        player = characters[0];
    }

    // Use this for initialization
    void Start() {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate() {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		if (focus && player != null)
            transform.position = player.transform.position + offset;
    }

    public IEnumerator SwapFocus() {
        yield return new WaitForSeconds(0.1f);
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");
        if (characters.Length != 1) {
            Debug.LogError("More than one character Active!");
            StartCoroutine(SwapFocus());
        } else {
            player = characters[0];
        }
    }

    public void Focus(bool f) { focus = f; }
}