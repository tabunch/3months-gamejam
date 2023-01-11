using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyObject : MonoBehaviour
{
    [SerializeField] GameObject pointer;
    Pointer pt;

    // Start is called before the first frame update
    void Start()
    {
        pt = pointer.GetComponent<Pointer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && pt.target != null){
            Instantiate(pt.target);
        }
    }
}
