using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CollisionTag : MonoBehaviour
{
    public bool isTouched;
    [SerializeField] string objectTag;
    private Regex regex;
    // Start is called before the first frame update
    void Start()
    {
        isTouched = false;
        regex = new Regex(objectTag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(regex.IsMatch(other.gameObject.tag)){
            isTouched = true;
        }
    }
}
