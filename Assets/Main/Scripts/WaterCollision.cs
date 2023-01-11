using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    [SerializeField] GameObject root;
    Animator anim;
    private int level;
    private List<int> objectIds;

    // Start is called before the first frame update
    void Start()
    {
        anim = root.GetComponent<Animator>();
        level = 0;
        objectIds = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        int id = other.gameObject.GetInstanceID();
        if(objectIds.Contains(id)){
            return;
        }
        objectIds.Add(id);
        level++;
        anim.SetInteger("level", level);
    }
}
