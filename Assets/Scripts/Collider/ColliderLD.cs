using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLD : MonoBehaviour
{
    public bool CollisionLD;

    private void OnCollisionStay2D(Collision2D collision)
    {
        CollisionLD = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CollisionLD = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        CollisionLD = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
