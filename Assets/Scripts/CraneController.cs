using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    // Movement speed
    public float speed = 2;

    public Rigidbody2D theRB;

    // Flap force
    public float force = 300;

    [SerializeField] float flapBuffer = 0.2f;
    float flapBufferTimer = 0;
    [SerializeField] bool canFlap = true;


    // Use this for initialization
    void Start()
    {

        theRB = GetComponent<Rigidbody2D>();

        // Fly towards the right
        theRB.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

        HandleMovemet();
        HandleFlap();


    }

    void HandleFlap()
    {
        // Limit flap
        if (flapBufferTimer > 0)
        {
            flapBufferTimer -= Time.deltaTime;
        }
        else
        {
            canFlap = true;
        }

        // Flap
        if (Input.GetKeyDown(KeyCode.Space) && canFlap)
        {
            theRB.velocity = Vector2.zero;
            theRB.AddForce(Vector2.up * force);
            flapBufferTimer = flapBuffer;
            canFlap = false;
        }
    }

    void HandleMovemet()
    {
        // Move sideways
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, theRB.velocity.y);

        // Handle direction change
        if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (theRB.velocity.x < 0)
        {
            transform.localScale = Vector3.one;
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            // Do somethinng
        }
        else
        {
            // Do somethinng
        }
    }
}
