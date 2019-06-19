using UnityEngine;
using System.Collections;

public class PistonController : MonoBehaviour
{
   public enum pistonMoveType
    {
        None = 0,
        Close,
        Separate,
        Fixed
    };

    public pistonMoveType topPistonMovement;
    public pistonMoveType bottomPistonMovement;

    Vector2 topDefaultPosition;
    Vector2 bottomDefaultPosition;

    Transform topPistonTransform;
    Transform bottomPistonTransform;

    float pistonMoveSpeed;

    // Use this for initialization
    void Awake ()
    {
        pistonMoveSpeed = 0.0128f;
        topPistonTransform = transform.Find("Piston_Top").GetComponent<Transform>();
        bottomPistonTransform = transform.Find("Piston_Bottom").GetComponent<Transform>();

        topDefaultPosition = topPistonTransform.position;
        bottomDefaultPosition = bottomPistonTransform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 topPistonNew = topPistonTransform.position;
        Vector2 bottomPistonNew = bottomPistonTransform.position;

        if (topPistonTransform.rotation.z == 0)
        {
            if (Input.GetKey(KeyCode.F1))
            {
                topPistonNew.y -= pistonMoveSpeed;
                bottomPistonNew.y += pistonMoveSpeed;
            }
            else
            {
                if (topPistonNew.y < topDefaultPosition.y)
                {
                    topPistonNew.y += pistonMoveSpeed;
                }
                if (bottomPistonNew.y > bottomDefaultPosition.y)
                {
                    bottomPistonNew.y -= pistonMoveSpeed;
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.F1))
            {
                topPistonNew.x += pistonMoveSpeed;
                bottomPistonNew.x -= pistonMoveSpeed;
            }
            else
            {
                if (topPistonNew.x > topDefaultPosition.x)
                {
                    topPistonNew.x -= pistonMoveSpeed;
                }
                if (bottomPistonNew.x < bottomDefaultPosition.x)
                {
                    bottomPistonNew.x += pistonMoveSpeed;
                }
            }
        }

        topPistonTransform.position = topPistonNew;
        bottomPistonTransform.position = bottomPistonNew;
	}
}
