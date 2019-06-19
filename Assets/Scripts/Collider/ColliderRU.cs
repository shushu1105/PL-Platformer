using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRU : MonoBehaviour
{
    public bool CollisionRU;

    private void OnCollisionStay2D(Collision2D collision)
    {
        CollisionRU = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CollisionRU = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        CollisionRU = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
