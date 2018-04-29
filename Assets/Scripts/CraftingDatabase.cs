using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingDatabase : MonoBehaviour {

	[System.Serializable]
    public class Recipe {
        public GameObject result;
        public string[] ingredients;
    }

    public Recipe[] recipies;
    [HideInInspector]
    public static CraftingDatabase ins;

    private void Awake() {
        ins = this;
    }

    public GameObject Craft(string[] items) {
        Array.Sort(items);
        foreach (Recipe recipe in recipies) {
            Array.Sort(recipe.ingredients);
            if (Enumerable.SequenceEqual(items, recipe.ingredients))
                return recipe.result;
        }
        return null;
    }
}
