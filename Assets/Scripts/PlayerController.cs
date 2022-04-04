using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rB2D;

    public float runSpeed;

    public float jumpSpeed;

    bool shouldJump;

    // Start is called before the first frame update
    void Start()
    {
        rB2D = GetComponent<Rigidbody2D>();


    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        rB2D.velocity = new Vector2(horizontalInput * runSpeed * Time.deltaTime, rB2D.velocity.y);

        if(shouldJump)
        {
            rB2D.velocity = new Vector2(rB2D.velocity.x, rB2D.velocity.y + jumpSpeed);
            shouldJump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown( KeyCode.Space ))
        {
            int levelMask = LayerMask.GetMask("Level");

            if( Physics2D.BoxCast( transform.position, new Vector2( 1f, .1f ), 0f, Vector2.down, .01f, levelMask ) )
            {
                shouldJump = true;

            }

            
        }
    }
}
