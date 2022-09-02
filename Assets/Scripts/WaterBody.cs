using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBody : MonoBehaviour
{
    Animator anim;
    int level;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
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
}
