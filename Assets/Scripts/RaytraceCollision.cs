using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RaytraceCollision : MonoBehaviour
{
    public float width;
    public float height;
    public float moveSpeed;
    public float position;

    bool isJump;
    bool blockJump;
    Red_Collider redCollider;
    Rigidbody2D rb;
    PlaySFX playSfx;

    Vector3 Teleport;

    Vector2 rbVel;

    private void OnTriggerStay2D(Collider2D collision)
    {
        blockJump = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        blockJump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            collision.GetComponentInParent<PlaySFX>().playSFX = true;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //NOT YET WORKING PROPERLY!! TODO
        if (collision.gameObject.CompareTag("Moving"))
        {
            Vector2 Speed = rb.velocity;
            Speed.x = collision.gameObject.GetComponent<Moving_Platform>().moveSpeedx;

            //Vector2 Speed = new Vector2(collision.GetComponent<Moving_Platform>().moveSpeedx, rb.velocity.y);
            Vector3 newPos = new Vector3(transform.position.x + Speed.x, transform.position.y, -10.0f);
            transform.position = newPos;
        }
    }

    // Use this for initialization
    void Start()
    {
        width = 0.64f;
        height = 0.64f;
        moveSpeed = 8.0f;
        isJump = false;
        redCollider = transform.Find("red").GetComponent<Red_Collider>();
        rb = GetComponent<Rigidbody2D>();
        Teleport = new Vector2(0.0f, 0.0f);
        playSfx = GetComponent<PlaySFX>();
        blockJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        rbVel = rb.velocity;
        isJump = !redCollider.collideD;

        if (Input.GetKey(KeyCode.LeftArrow) && !redCollider.collideL)
        {
            rbVel.x = -moveSpeed;
        }

        else if (Input.GetKey(KeyCode.RightArrow) && !redCollider.collideR)
        {
            rbVel.x = moveSpeed;
        }
        else
        {
            if (rb.velocity.x > 0.1f)
            {
                rbVel.x -= 0.2f;
            }
            else if (rb.velocity.x < -0.1f)
            {
                rbVel.x += 0.2f;
            }
            else
            {
                rbVel.x = 0;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow) && !isJump && !blockJump)
        {
            rbVel.y = 30 * height;
            isJump = true;
            playSfx.playSFX = true;
        }

        if (Input.GetKey(KeyCode.PageUp) || (redCollider.collideU && redCollider.collideD))
        {
            width += 0.0128f;
            height -= 0.0128f;
        }
        if (Input.GetKey(KeyCode.PageDown) || (redCollider.collideL && redCollider.collideR))
        {
            height += 0.0128f;
            width -= 0.0128f;
        }

        if (Input.GetKey(KeyCode.F5))
        {
            height = 0.64f;
            width = 0.64f;
        }

        if (width != 0.64f && height != 0.64f)
        {
            if (height > width)
            {
                height -= 0.00064f;
                width += 0.00064f;
            }
            else
            {
                height += 0.00064f;
                width -= 0.00064f;
            }
        }

        if (width <= 0.128f || height <= 0.128f || Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level_Tutorial");
        }
        rb.velocity = rbVel;
    }
}
