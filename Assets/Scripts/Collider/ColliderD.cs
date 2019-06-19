using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderD : MonoBehaviour
{
    public bool CollisionD;

    private void OnCollisionStay2D(Collision2D collision)
    {
        CollisionD = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CollisionD = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        CollisionD = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
