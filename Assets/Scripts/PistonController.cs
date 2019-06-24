using UnityEngine;
using System.Collections;

public class PistonController : MonoBehaviour
{
    public enum pistonSetNumber
    {
        zero,
        one,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine
    }
    public enum pistonMoveType
    {
        None = 0,
        Close,
        Separate,
        Fixed
    };

    public pistonMoveType topPistonMovement;
    public pistonMoveType bottomPistonMovement;
    public pistonSetNumber linkNumber;

    GameObject[] allLevers;
    public LeverController linkedLever;
    bool closePiston;
    bool isLimit;

    Vector2 topDefaultPosition;
    Vector2 bottomDefaultPosition;

    Transform topPistonTransform;
    Transform bottomPistonTransform;

    float pistonMoveSpeed;

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("in");
        if (collision.gameObject.CompareTag("Piston"))
        {
            isLimit = true;
        }
        else
        {
            isLimit = false;
        }
    }

    // Use this for initialization
    void Awake ()
    {
        isLimit = false;
        pistonMoveSpeed = 0.0064f;
        topPistonTransform = transform.Find("Piston_Top").GetComponent<Transform>();
        bottomPistonTransform = transform.Find("Piston_Bottom").GetComponent<Transform>();

        topDefaultPosition = topPistonTransform.position;
        bottomDefaultPosition = bottomPistonTransform.position;

        allLevers = GameObject.FindGameObjectsWithTag("Lever");
        for (int i = 0; i < allLevers.Length; i++)
        {
            linkedLever = allLevers[i].GetComponent<LeverController>();
            if (linkedLever.linkedPiston == linkNumber)
            {
                break;
            }

            if (i == allLevers.Length - 1)
            {
                Debug.LogError("Piston Link not found:" + linkNumber);
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 topPistonNew = topPistonTransform.position;
        Vector2 bottomPistonNew = bottomPistonTransform.position;

        if (topPistonTransform.rotation.z == 0)
        {
            if ((Input.GetKey(KeyCode.DownArrow) || closePiston) && !isLimit)
            {
                topPistonNew.y -= pistonMoveSpeed;
                bottomPistonNew.y += pistonMoveSpeed;
            }
            else if(!isLimit)
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
            if (Input.GetKey(KeyCode.DownArrow) || closePiston)
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

        if (linkedLever.isOn)
        {
            closePiston = true;
        }
        else
        {
            closePiston = false;
        }

        topPistonTransform.position = topPistonNew;
        bottomPistonTransform.position = bottomPistonNew;
	}
}
