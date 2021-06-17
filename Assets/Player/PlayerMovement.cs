using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove;
    public float moveSpeed = 5f;

    [HideInInspector]
    public Rigidbody2D rb;

    Vector2 move;


    // Start is called before the first frame update
    void Start()
    {
        // ANNEX RIGIDBODY
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // DETECT INPUT KEYS
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // MUST NOT MOVE WHEN DOING ACTION
        if (canMove)
        {
            rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
