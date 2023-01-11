using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBody : MonoBehaviour
{
    [SerializeField] GameObject root;
    Animator anim;
    int level;
    // Start is called before the first frame update
    void Start()
    {
        anim = root.GetComponent<Animator>();
        level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)){
            anim.SetInteger("level", 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        level += 1;
        anim.SetInteger("level", level);
    }

    private void OnTriggerExit2D(Collider2D other) {
        level -= 1;
        anim.SetInteger("level", level);
    }
}
