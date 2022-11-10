using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 pointerPos;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        pointerPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));
        this.transform.position = pointerPos;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(Input.GetMouseButton(0) && other.gameObject.CompareTag("Copyable")){
            target = other.gameObject;
        }
    }
}
