using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RadialButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Image circle;
    public Text label;

    [HideInInspector]
    public RadialMenu myMenu;
    [HideInInspector]
    public float speed = 8f;
    [HideInInspector]
    public MethodInfo method;
    [HideInInspector]
    public Interactable receiver;


    Color defaultColor;

    public void Anim() {
        StartCoroutine(AnimateButton());
    }

    IEnumerator AnimateButton() {
        transform.localScale = Vector3.zero;
        float timer = 0f;
        while (timer < (1 / speed)) {
            timer += Time.deltaTime;
            transform.localScale = Vector3.one * timer * speed;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        myMenu.selected = this;
        defaultColor = circle.color;
        circle.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData) {
        myMenu.selected = null;
        circle.color = defaultColor;
    } 
}
