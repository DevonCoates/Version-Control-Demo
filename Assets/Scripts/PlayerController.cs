using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool canMove;
    private Rigidbody2D theRB2D;
    public float dashForce;

    // Start is called before the first frame update
    void Start()
    {
        theRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(theRB2D.position.y);
        Debug.Log(theRB2D.position.x);
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            canMove = true;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        Jump();
        Teleport();
        Dash();
    }

    void MovePlayer()
    {
        if (canMove)
        {
            theRB2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, theRB2D.velocity.y);
        }
    }

    void Jump()
    {
        if((theRB2D.position.y < -3.4) && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            theRB2D.velocity = new Vector2(theRB2D.velocity.x, jumpForce);
        }
    }
    void Teleport()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Vector2 teleport = new Vector2((-1 * theRB2D.position.x), (-1 * theRB2D.position.y));
            theRB2D.MovePosition(teleport);
        }
    }
    void Dash()
    {
        dashForce = 100f;
        if(Input.GetKeyDown(KeyCode.R))
        {
            theRB2D.velocity = new Vector2((theRB2D.position.x + dashForce), theRB2D.velocity.y);
        }
    }
}
