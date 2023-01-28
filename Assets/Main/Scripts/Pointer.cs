using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 pointerPos;
    public GameObject target;
    [SerializeField] GameObject copiedObject;
    Image copiedObjectIcon;
    private Color selectedColor;
    private Color defaultColor;
    private SpriteRenderer targetSprite;
    private bool isMouseOvered;
    private Regex regex;

    // Start is called before the first frame update
    void Start()
    {
        target = null;
        copiedObjectIcon = copiedObject.GetComponent<Image>();
        selectedColor = new Color(255.0f/255.0f, 255.0f/255.0f, 0.0f/255.0f, 255.0f/255.0f);
        defaultColor = new Color(255.0f/255.0f, 255.0f/255.0f, 255.0f/255.0f, 255.0f/255.0f);
        isMouseOvered = false;
        regex = new Regex("Copyable");
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        pointerPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));
        this.transform.position = pointerPos;
        if(Input.GetMouseButton(0) && isMouseOvered){
            copiedObjectIcon.sprite = targetSprite.sprite;
            copiedObjectIcon.color = defaultColor;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(regex.IsMatch(other.gameObject.tag)){
            target = other.gameObject;
            targetSprite = target.GetComponent<SpriteRenderer>();
            targetSprite.color = selectedColor;
            isMouseOvered = true;
            /*
            if(Input.GetMouseButton(0)){
                copiedObjectIcon.sprite = targetSprite.sprite;
                copiedObjectIcon.color = defaultColor;
            }
            */
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(target != null){
            targetSprite.color = defaultColor;
            isMouseOvered = false;
        }
    }
}
