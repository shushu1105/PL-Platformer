using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderU : MonoBehaviour
{
    public bool CollisionU;

    private void OnCollisionStay2D(Collision2D collision)
    {
        CollisionU = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CollisionU = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        CollisionU = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
