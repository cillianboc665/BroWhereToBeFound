using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D body;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float checkDist = 0.1f;
    public bool Grounded;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        Grounded = Physics2D.Raycast(groundCheck.position, Vector2.down, checkDist, groundLayer);

        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);

        float horizInput = Input.GetAxis("Horizontal");
        if (horizInput > 0.01f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}
