using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRD : MonoBehaviour
{
    public bool CollisionRD;

    private void OnCollisionStay2D(Collision2D collision)
    {
        CollisionRD = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CollisionRD = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        CollisionRD = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
