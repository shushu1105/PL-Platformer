using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour
{
    public Vector2 cameraBorder;

    private Transform playerTransform;
    private RaytraceCollision raytraceCollision;
    private Vector3 cameraPos;
    // Use this for initialization
    void Start ()
    {
        cameraBorder.x = 2;
        cameraBorder.y = 1;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        raytraceCollision = GameObject.FindGameObjectWithTag("Player").GetComponent<RaytraceCollision>();
        cameraPos = playerTransform.position;
        cameraPos.z = -10;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Mathf.Abs(cameraPos.x - playerTransform.position.x) > cameraBorder.x)
        {
            if (cameraPos.x > playerTransform.position.x)
            {
                cameraPos.x -= raytraceCollision.moveSpeed;
            }
            if (cameraPos.x < playerTransform.position.x)
            {
                cameraPos.x += raytraceCollision.moveSpeed;
            }
        }

        if (Mathf.Abs(cameraPos.y - playerTransform.position.y) > cameraBorder.y)
        {
            cameraPos.y -= raytraceCollision.velocity;
        }
        transform.position = cameraPos;
    }
}
