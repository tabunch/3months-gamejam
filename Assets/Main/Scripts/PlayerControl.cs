using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] GameObject foot;
    CollisionTag collisionTag;
    [SerializeField] float jumpForce;
    Vector2 velocityVector;
    [SerializeField] float runVelocity;
    [SerializeField] Animator animator;
    private KeyCode jumpKey, leftMoveKey, rightMoveKey;
    private Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        collisionTag = foot.GetComponent<CollisionTag>();
        velocityVector = new Vector2(0,0);
        jumpKey = KeyCode.Space;
        leftMoveKey = KeyCode.LeftArrow;
        rightMoveKey = KeyCode.RightArrow;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(jumpKey) && collisionTag.isTouched){
            rigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            collisionTag.isTouched = false;
        }

        if(Input.GetKey(rightMoveKey)){
            Run(runVelocity);
            scale.x = 1;
            transform.localScale = scale;
            if(collisionTag.isTouched){
                animator.SetBool("IsMoving", true);
            }
            else{
                animator.SetBool("IsMoving", false);
            }
        }
        else if(Input.GetKey(leftMoveKey)){
            Run(-runVelocity);
            scale.x = -1;
            transform.localScale = scale;
            if(collisionTag.isTouched){
                animator.SetBool("IsMoving", true);
            }
            else{
                animator.SetBool("IsMoving", false);
            }
        }
        else{
            Run(0);
            animator.SetBool("IsMoving", false);
        }
    }

    void Run(float velocity){
        velocityVector.x = velocity;
        velocityVector.y = rigidbody2d.velocity.y;
        rigidbody2d.velocity = velocityVector;
    }
}
