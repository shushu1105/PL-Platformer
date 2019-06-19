using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderF : MonoBehaviour
{
    public bool CollisionF;

    private void OnCollisionStay2D(Collision2D collision)
    {
        CollisionF = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CollisionF = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        CollisionF = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
