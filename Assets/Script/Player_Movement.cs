using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anime;
    private SpriteRenderer sprite;
    //check if the ground is jumpable
    [SerializeField] private LayerMask jumpableGround;
    private BoxCollider2D coll;
    //player movement speed
    [SerializeField] private float dirX = 0f;
    //player jump hight
    [SerializeField] private float jumpForce = 14f;
    // Start is called before the first frame update
    void Start()
    {
        //set up all the component so they can work later
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //player movement by adding velocity on the player object, when player hit the key on the keyboard, player will move based on what was pressed
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
        //if player hit the jump butten which is the space, and player was on the ground, they can jump by adding velocity to the player
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    //check if player was on ground or not
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size,0f, Vector2.down, .1f, jumpableGround);
    }
    }

