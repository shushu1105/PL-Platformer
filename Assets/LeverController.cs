using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public PistonController.pistonSetNumber linkedPiston;
    public bool isOn;

    bool isOnCollision;
    Vector2 defaultScale;
    Vector2 currentScale;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnCollision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnCollision = false;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        defaultScale = GetComponent<Transform>().localScale;   
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            currentScale = defaultScale;
        }
        else
        {
            currentScale = new Vector2(-defaultScale.x, defaultScale.y);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnCollision)
        {
            isOn = !isOn;
        }

        transform.localScale = currentScale;
    }
}
