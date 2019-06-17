using UnityEngine;
using System.Collections;

public class RaytraceCollision : MonoBehaviour
{
    public float terminalV;
    public float gravity;
    public float width;
    public float height;
    public float velocity;
    public float moveSpeed;

    private float hitBoxPercentage;
    private bool hitLeft;
    private bool hitRight;
    private bool hitFloor;
    private bool hitCeiling;
    private Vector2 playerPosition;
    private RaycastHit2D checkRaycast(Vector2 direction, float distance)
    {
        return Physics2D.Raycast(transform.position, direction, distance);
    }

    private void raycastCollision()
    {
        RaycastHit2D[] hit = new RaycastHit2D[8];

        float p_width = width * hitBoxPercentage;
        float p_height = height * hitBoxPercentage;

        //30
        hit[0] = checkRaycast(new Vector2( width  , p_height) , Mathf.Sqrt((width * width) + (p_height * p_height)));
        hit[1] = checkRaycast(new Vector2(p_width , -height)  , Mathf.Sqrt((p_width * p_width) + (height * height)));
        hit[2] = checkRaycast(new Vector2(-width  , -p_height), Mathf.Sqrt((width * width) + (p_height * p_height)));
        hit[3] = checkRaycast(new Vector2(-p_width,  height)  , Mathf.Sqrt((p_width * p_width) + (height * height)));

        //60
        hit[4] = checkRaycast(new Vector2(width   , -p_height), Mathf.Sqrt((width * width) + (p_height * p_height)));
        hit[5] = checkRaycast(new Vector2(-p_width , -height) , Mathf.Sqrt((p_width * p_width) + (height * height)));
        hit[6] = checkRaycast(new Vector2(-width  , p_height) , Mathf.Sqrt((width * width) + (p_height * p_height)));
        hit[7] = checkRaycast(new Vector2(p_width, height)    , Mathf.Sqrt((p_width * p_width) + (height * height)));

        if (hit[1].collider || hit[5].collider)         //down
        {
            playerPosition.y += height - Mathf.Max(hitBoxPercentage * hit[1].distance, hitBoxPercentage * hit[5].distance);
            if (velocity > 0)
            {
                velocity = 0;
            }
            hitFloor = true;
        }
        else { hitFloor = false; }

        if (hit[0].collider || hit[4].collider)
        {
            playerPosition.x -= width - Mathf.Max(hit[0].distance * hitBoxPercentage, hit[4].distance * hitBoxPercentage);
            hitLeft = true;
        }
        else { hitLeft = false; }

        if (hit[2].collider || hit[6].collider)
        {
            playerPosition.x += width - Mathf.Max(hit[2].distance * hitBoxPercentage, hit[6].distance * hitBoxPercentage);
            hitRight = true;
        }
        else { hitRight = false; }
    }

    // Use this for initialization
    void Start()
    {
        terminalV = 1.0f;
        gravity = 0.01f;
        width = 0.64f;
        height = 0.64f;
        moveSpeed = 0.1f;
        hitBoxPercentage = 0.8f;
        playerPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity += gravity;
        if (velocity > terminalV)
        {
            velocity = terminalV;
        }
        raycastCollision();

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!hitRight)
            {
                playerPosition.x -= moveSpeed;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!hitLeft)
            {
                playerPosition.x += moveSpeed;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (hitFloor)
            {
                velocity = -0.25f;
            }
        }

        playerPosition.y -= velocity;
        transform.position = playerPosition;
    }
}
