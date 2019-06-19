using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderR : MonoBehaviour
{
    public bool CollisionR;

    private void OnCollisionStay2D(Collision2D collision)
    {
        CollisionR = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CollisionR = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        CollisionR = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
