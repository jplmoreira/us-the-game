using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStress : Interactable {

    public int amount;

	public void Interact_ChangeStress() {
        if (amount > 0)
            StressBar.ins.increment(amount);
        else
            StressBar.ins.decrement(-amount);
    }
}
