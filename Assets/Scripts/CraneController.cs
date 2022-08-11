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

    [SerializeField] bool isFalling = false;

    [SerializeField] float originalGravity = 0.5f;

    Animator animator;

    // Use this for initialization
    void Start()
    {

        theRB = GetComponent<Rigidbody2D>();
        theRB.gravityScale = originalGravity;

        animator = GetComponent<Animator>();

        // Fly towards the right
        theRB.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameActive)
        {
            HandleMovemet();

            if (GameManager.instance.isFreefalling)
            {
                HandleFreefall();
            }
            else
            {
                HandleFlap();
            }
        }
    }

    void HandleFreefall()
    {
        theRB.gravityScale = originalGravity / 1.5f;
        theRB.velocity = new Vector2(theRB.velocity.x, -1f);

        //For playing the animation
        animator.enabled = false;
    }

    void HandleFlap()
    {
        animator.enabled = true;
        theRB.gravityScale = originalGravity;

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

            GameManager.instance.DecreaseMana(GameManager.instance.manaFlapRate);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mana")
        {
            GameManager.instance.IncreaseMana(20);
            GameManager.instance.isFreefalling = false;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Deadzone")
        {
            GameManager.instance.LoseGame();
        }
    }
}
