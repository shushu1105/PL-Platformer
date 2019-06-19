using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatTitle : MonoBehaviour
{ 
    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 360) counter = 0;
        transform.position = new Vector2(transform.position.x, 2.0f * Mathf.Sin(counter*Mathf.Deg2Rad));
        counter += 0.25f;
    }
}
