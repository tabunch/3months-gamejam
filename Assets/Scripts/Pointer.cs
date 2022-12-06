using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 pointerPos;
    public GameObject target;
    [SerializeField] GameObject copiedObject;
    Image copiedObjectIcon;

    // Start is called before the first frame update
    void Start()
    {
        target = null;
        copiedObjectIcon = copiedObject.GetComponent<Image>();
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
            copiedObjectIcon.sprite = target.GetComponent<SpriteRenderer>().sprite;
            copiedObjectIcon.color = new Color(255.0f/255.0f, 255.0f/255.0f, 255.0f/255.0f, 255.0f/255.0f);
        }
    }
}
