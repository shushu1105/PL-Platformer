﻿using UnityEngine;
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
    public Vector2 playerPosition;
    private RaycastHit2D checkRaycast(Vector2 direction, float distance)
    {
        return Physics2D.Raycast(transform.position, direction, distance);
    }

    private void raycastCollision()
    {
        RaycastHit2D[] hit = new RaycastHit2D[16];

        float p_width = width * hitBoxPercentage;
        float p_height = height * hitBoxPercentage;
        float p_Lwidth = width * hitBoxPercentage * 2;
        float p_Lheight = height * hitBoxPercentage * 2;

        //30
        hit[0] = checkRaycast(new Vector2(width, p_height), (float)System.Math.Sqrt((width * width) + (p_height * p_height)));
        hit[1] = checkRaycast(new Vector2(p_width, -height), (float)System.Math.Sqrt((p_width * p_width) + (height * height)));
        hit[2] = checkRaycast(new Vector2(-width, -p_height), (float)System.Math.Sqrt((width * width) + (p_height * p_height)));
        hit[3] = checkRaycast(new Vector2(-p_width, height), (float)System.Math.Sqrt((p_width * p_width) + (height * height)));

        //60
        hit[4] = checkRaycast(new Vector2(width, -p_height), (float)System.Math.Sqrt((width * width) + (p_height * p_height)));
        hit[5] = checkRaycast(new Vector2(-p_width, -height), (float)System.Math.Sqrt((p_width * p_width) + (height * height)));
        hit[6] = checkRaycast(new Vector2(-width, p_height), (float)System.Math.Sqrt((width * width) + (p_height * p_height)));
        hit[7] = checkRaycast(new Vector2(p_width, height), (float)System.Math.Sqrt((p_width * p_width) + (height * height)));

        //15
        hit[8] = checkRaycast(new Vector2(width, p_Lheight), (float)System.Math.Sqrt((width * width) + (p_Lheight * p_Lheight)));
        hit[9] = checkRaycast(new Vector2(p_Lwidth, -height), (float)System.Math.Sqrt((p_Lwidth * p_Lwidth) + (height * height)));
        hit[10] = checkRaycast(new Vector2(-width, -p_Lheight), (float)System.Math.Sqrt((width * width) + (p_Lheight * p_Lheight)));
        hit[11] = checkRaycast(new Vector2(-p_Lwidth, height), (float)System.Math.Sqrt((p_Lwidth * p_Lwidth) + (height * height)));

        //75
        hit[12] = checkRaycast(new Vector2(width, -p_Lheight), (float)System.Math.Sqrt((width * width) + (p_Lheight * p_Lheight)));
        hit[13] = checkRaycast(new Vector2(-p_Lwidth, -height), (float)System.Math.Sqrt((p_Lwidth * p_Lwidth) + (height * height)));
        hit[14] = checkRaycast(new Vector2(-width, p_Lheight), (float)System.Math.Sqrt((width * width) + (p_Lheight * p_Lheight)));
        hit[15] = checkRaycast(new Vector2(p_Lwidth, height), (float)System.Math.Sqrt((p_Lwidth * p_Lwidth) + (height * height)));

        Debug.DrawRay(playerPosition, new Vector2(width, p_height));
        Debug.DrawRay(playerPosition, new Vector2(p_width, -height));
        Debug.DrawRay(playerPosition, new Vector2(-width, -p_height));
        Debug.DrawRay(playerPosition, new Vector2(-p_width, height));

        Debug.DrawRay(playerPosition, new Vector2(width, -p_height));
        Debug.DrawRay(playerPosition, new Vector2(-p_width, -height));
        Debug.DrawRay(playerPosition, new Vector2(-width, p_height));
        Debug.DrawRay(playerPosition, new Vector2(p_width, height));

        Debug.DrawRay(playerPosition, new Vector2(width, p_Lheight));
        Debug.DrawRay(playerPosition, new Vector2(p_Lwidth, -height));
        Debug.DrawRay(playerPosition, new Vector2(-width, -p_Lheight));
        Debug.DrawRay(playerPosition, new Vector2(-p_Lwidth, height));

        Debug.DrawRay(playerPosition, new Vector2(width, -p_Lheight));
        Debug.DrawRay(playerPosition, new Vector2(-p_Lwidth, -height));
        Debug.DrawRay(playerPosition, new Vector2(-width, p_Lheight));
        Debug.DrawRay(playerPosition, new Vector2(p_Lwidth, height));

        if (hit[0].collider || hit[4].collider)
        {
            playerPosition.x -= width - (float)System.Math.Max(hit[0].distance * System.Math.Sin(System.Math.Atan2(width, p_height)), hit[4].distance * System.Math.Sin(System.Math.Atan2(width, p_height)));
            hitLeft = true;
        }
        else if (hit[8].collider || hit[12].collider)
        {
            playerPosition.x -= width - (float)System.Math.Max(hit[8].distance * System.Math.Sin(System.Math.Atan2(width, p_Lheight)), hit[12].distance * System.Math.Sin(System.Math.Atan2(width, p_Lheight)));
            //hitLeft = true;
        }
        else { hitLeft = false; }

        if (hit[2].collider || hit[6].collider)
        {
            playerPosition.x += width - (float)System.Math.Max(hit[2].distance * System.Math.Sin(System.Math.Atan2(width, p_height)), hit[6].distance * System.Math.Sin(System.Math.Atan2(width, p_height)));
            hitRight = true;
        }
        else if (hit[10].collider || hit[14].collider)
        {
            playerPosition.x += width - (float)System.Math.Max(hit[10].distance * System.Math.Sin(System.Math.Atan2(width, p_Lheight)), hit[14].distance * System.Math.Sin(System.Math.Atan2(width, p_Lheight)));
            //hitRight = true;
        }
        else { hitRight = false; }

        if (hit[1].collider || hit[5].collider)         //down
        {
            playerPosition.y += height - (float)System.Math.Max(System.Math.Cos(System.Math.Atan2(p_width, height)) * hit[1].distance, System.Math.Cos(System.Math.Atan2(p_width, height)) * hit[5].distance);
            if (velocity > 0)
            {
                velocity = 0;
            }
            hitFloor = true;
        }
        else if (hit[9].collider || hit[13].collider)
        {
            playerPosition.y += height - (float)System.Math.Max(System.Math.Cos(System.Math.Atan2(p_Lwidth, height)) * hit[9].distance, System.Math.Cos(System.Math.Atan2(p_Lwidth, height)) * hit[13].distance);
            if (velocity > 0)
            {
                velocity = 0;
            }
            //hitFloor = true;
        }
        else { hitFloor = false; }

        if (hit[3].collider || hit[7].collider)         //up
        {
            playerPosition.y -= height - (float)System.Math.Max(System.Math.Cos(System.Math.Atan2(p_width, height)) * hit[3].distance, System.Math.Cos(System.Math.Atan2(p_width, height)) * hit[7].distance);

            velocity = 0.1f;
            hitCeiling = true;
        }
        else if (hit[11].collider || hit[15].collider)         //up
        {
            playerPosition.y -= height - (float)System.Math.Max(System.Math.Cos(System.Math.Atan2(p_Lwidth, height)) * hit[11].distance, System.Math.Cos(System.Math.Atan2(p_Lwidth, height)) * hit[15].distance);

            velocity = 0.1f;
            //hitCeiling = true;
        }
        else { hitCeiling = false; }

        if (hitCeiling && hitFloor)
        {
            height -= 0.01f;
            width += 0.01f;
        }
        else if (hitLeft && hitRight)
        {
            width -= 0.01f;
            height += 0.01f;
        }
    }

    // Use this for initialization
    void Start()
    {
        terminalV = 1.0f;
        gravity = 0.01f;
        width = 0.64f;
        height = 0.64f;
        moveSpeed = 0.1f;
        hitBoxPercentage = 0.4f;
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

        if (Input.GetKey(KeyCode.PageUp))
        {
            width += 0.01f;
            height -= 0.01f;
        }
        if (Input.GetKey(KeyCode.PageDown))
        {
            height += 0.01f;
            width -= 0.01f;
        }

        if (Input.GetKey(KeyCode.F5))
        {
            height = 0.64f;
            width = 0.64f;
        }

        playerPosition.y -= velocity;
        transform.position = playerPosition;
    }
}
