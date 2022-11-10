using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] GameObject foot;
    Foot footScript;
    [SerializeField] float jumpForce;
    Vector2 velocityVector;
    [SerializeField] float runVelocity;
    private KeyCode jumpKey, leftMoveKey, rightMoveKey;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        footScript = foot.GetComponent<Foot>();
        velocityVector = new Vector2(0,0);
        jumpKey = KeyCode.Space;
        leftMoveKey = KeyCode.RightArrow;
        rightMoveKey = KeyCode.LeftArrow;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(jumpKey) && footScript.isGrounded){
            rigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            footScript.isGrounded = false;
        }

        if(Input.GetKey(rightMoveKey)){
            Run(runVelocity);
        }
        else if(Input.GetKey(leftMoveKey)){
            Run(-runVelocity);
        }
        else{
            Run(0);
        }
    }

    void Run(float velocity){
        velocityVector.x = velocity;
        velocityVector.y = rigidbody2d.velocity.y;
        rigidbody2d.velocity = velocityVector;
    }
}
