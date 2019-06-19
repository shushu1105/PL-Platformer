using UnityEngine;
using System.Collections;

public class RaytraceCollision : MonoBehaviour
{
    public float width;
    public float height;
    public float moveSpeed;

    bool isJump;

    Red_Collider redCollider;
    Rigidbody2D rb;

    Vector2 rbVel;

    // Use this for initialization
    void Start()
    {
        width = 0.64f;
        height = 0.64f;
        moveSpeed = 16.0f;
        isJump = false;
        redCollider = transform.Find("red").GetComponent<Red_Collider>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rbVel = rb.velocity;
        isJump = !redCollider.collideD;

        if (Input.GetKey(KeyCode.LeftArrow)&& !redCollider.collideL)
        {
            rbVel.x = -moveSpeed;
        }

        else if (Input.GetKey(KeyCode.RightArrow) && !redCollider.collideR)
        {
            rbVel.x = moveSpeed;
        }
        else
        {
            rbVel.x = 0;
        }

        if (Input.GetKey(KeyCode.Space) && !isJump)
        {
            Debug.Log(height);
            rbVel.y = 30 * height;
            isJump = true;
        }

        if (Input.GetKey(KeyCode.PageUp) || (redCollider.collideU && redCollider.collideD))
        {
            width += 0.01f;
            height -= 0.01f;
        }
        if (Input.GetKey(KeyCode.PageDown) || (redCollider.collideL && redCollider.collideR))
        {
            height += 0.01f;
            width -= 0.01f;
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
                height -= 0.001f;
                width += 0.001f;
            }
            else
            {
                height += 0.001f;
                width -= 0.001f;
            }
        }

        if (width <= 0 || height <= 0)
        {
            Debug.Log("death");
        }
        rb.velocity = rbVel;
    }
}
