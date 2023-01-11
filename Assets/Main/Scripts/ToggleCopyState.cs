using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCopyState : MonoBehaviour
{
    private bool copyState;
    [SerializeField] GameObject pointer;
    [SerializeField] GameObject itemSetter;
    private GameObject[] copyableObjects;
    // Start is called before the first frame update
    void Start()
    {
        copyState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)){
            copyState = !copyState;
            copyableObjects = GameObject.FindGameObjectsWithTag("Copyable");
            if(copyState){
                pointer.SetActive(true);
                itemSetter.SetActive(false);
            }
            else{
                pointer.SetActive(false);
                itemSetter.SetActive(true);
            }
        }
    }
}
