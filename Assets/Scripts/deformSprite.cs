using UnityEngine;
using System.Collections;

public class deformSprite : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    RaytraceCollision raytraceCollision;
	// Use this for initialization
	void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        raytraceCollision = gameObject.GetComponentInParent<RaytraceCollision>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.localScale = new Vector2(raytraceCollision.width / 0.32f, raytraceCollision.height / 0.32f);
	}
}
