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
                cameraPos.x -= cameraPos.x - raytraceCollision.transform.position.x;
            }
            if (cameraPos.x < playerTransform.position.x)
            {
                cameraPos.x += cameraPos.x - raytraceCollision.transform.position.x;
            }
        }

        cameraPos = raytraceCollision.transform.position;

        transform.position = cameraPos;
    }
}
