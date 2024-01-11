using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    // Start is called before the first frame update
    private Rigidbody2D body;
    private BoxCollider2D collider;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;
    private float moveX = 0;
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float jumpSpeed = 11;
    private enum animationState {idle, running, jumping, falling};
    private animationState currentState = animationState.idle;
    [SerializeField] private AudioSource jumpingSound;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(moveX * moveSpeed, body.velocity.y);
        
        if(isGrounded()){
            if (Input.GetButtonDown("Jump"))
            {
                jumpingSound.Play();
                body.velocity = new Vector2(body.velocity.x, jumpSpeed);
                
            }
        }

        UpdateAnimation();
        
    }

    private void UpdateAnimation(){
        animationState state;

        if(moveX > 0f){
            state = animationState.running;
            sprite.flipX = false;
        } 
        else if(moveX < 0f){
            state = animationState.running;
            sprite.flipX = true;
        }
        else {
            state = animationState.idle;
        }

        if(body.velocity.y > 0.1f)
        {
            state = animationState.jumping;
        }
        else if (body.velocity.y < -0.1f)
        {
            state = animationState.falling;
        }
        

        anim.SetInteger("currState", (int) state);
    }

    private bool isGrounded(){
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
