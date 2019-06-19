using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Collider : MonoBehaviour
{
    public bool collideL;
    public bool collideD;
    public bool collideR;
    public bool collideU;

    public bool collideLU;
    public bool collideLD;
    public bool collideRU;
    public bool collideRD;

    private ColliderL C2DL;
    private ColliderD C2DD;
    private ColliderR C2DR;
    private ColliderU C2DU;

    private ColliderLU C2DLU;
    private ColliderLD C2DLD;
    private ColliderRD C2DRD;
    private ColliderRU C2DRU;

    private RaytraceCollision rc;
    private float radius;
    // Start is called before the first frame update
    void Awake()
    {
        C2DL = transform.Find("Collider_L").GetComponent<ColliderL>();
        C2DD = transform.Find("Collider_D").GetComponent<ColliderD>();
        C2DR = transform.Find("Collider_R").GetComponent<ColliderR>();
        C2DU = transform.Find("Collider_U").GetComponent<ColliderU>();

        C2DLU = transform.Find("Collider_LU").GetComponent<ColliderLU>();
        C2DLD = transform.Find("Collider_LD").GetComponent<ColliderLD>();
        C2DRD = transform.Find("Collider_RD").GetComponent<ColliderRD>();
        C2DRU = transform.Find("Collider_RU").GetComponent<ColliderRU>();

        rc = transform.parent.GetComponent<RaytraceCollision>();
        radius = 0.08f;

        collideL = false;
        collideD = false;
        collideR = false;
        collideU = false;

        collideLU = false;
        collideLD = false;
        collideRU = false;
        collideRD = false;
    }

    // Update is called once per frame
    void Update()
    {
        collideL = C2DL.CollisionL;
        collideR = C2DR.CollisionR;
        collideU = C2DU.CollisionU;
        collideD = C2DD.CollisionD;

        collideLU = C2DLU.CollisionLU;
        collideLD = C2DLD.CollisionLD;
        collideRD = C2DRD.CollisionRD;
        collideRU = C2DRU.CollisionRU;

        if (rc.width > rc.height)
        {
            radius = (rc.height / 0.64f) * 0.04f;
        }
        else if (rc.height > rc.width)
        {
            radius = (rc.width / 0.64f) * 0.04f;
        }

        C2DLU.GetComponent<CircleCollider2D>().radius = radius;
        C2DLD.GetComponent<CircleCollider2D>().radius = radius;
        C2DRU.GetComponent<CircleCollider2D>().radius = radius;
        C2DRD.GetComponent<CircleCollider2D>().radius = radius;
    }
}
