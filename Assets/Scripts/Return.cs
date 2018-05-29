using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : Interactable {

	public void Interact_Return() {
        SceneManager.LoadScene("Home Menu");
    }
}
