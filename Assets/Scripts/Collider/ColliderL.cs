using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderL : MonoBehaviour
{
    public bool CollisionL;


    private void OnCollisionStay2D(Collision2D collision)
    {
        CollisionL = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CollisionL = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        CollisionL = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
