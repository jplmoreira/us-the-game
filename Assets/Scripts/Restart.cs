using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : Interactable {

	public void Interact_Restart() {
        SceneManager.LoadScene("Demo");
    }
}
