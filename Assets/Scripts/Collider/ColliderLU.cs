using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLU: MonoBehaviour
{
    public bool CollisionLU;

    private void OnCollisionStay2D(Collision2D collision)
    {
        CollisionLU = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CollisionLU = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        CollisionLU = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
