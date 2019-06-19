using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    public float moveSpeedx;
    public float rangex;
    Vector2 defaultPosition;
    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (defaultPosition.x - transform.position.x > (rangex / 2))
        {
            moveSpeedx = Mathf.Abs(moveSpeedx);
        }

        if (transform.position.x - defaultPosition.x > (rangex / 2))
        {
            moveSpeedx = -Mathf.Abs(moveSpeedx);
        }

        transform.position = new Vector2(transform.position.x + moveSpeedx, transform.position.y);
    }
}
