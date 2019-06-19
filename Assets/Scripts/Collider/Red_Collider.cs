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

    public bool collideF;

    private ColliderL C2DL;
    private ColliderD C2DD;
    private ColliderR C2DR;
    private ColliderU C2DU;

    private ColliderF C2DF;

    private RaytraceCollision rc;
    private float radius;
    // Start is called before the first frame update
    void Awake()
    {
        C2DL = transform.Find("Collider_L").GetComponent<ColliderL>();
        C2DD = transform.Find("Collider_D").GetComponent<ColliderD>();
        C2DR = transform.Find("Collider_R").GetComponent<ColliderR>();
        C2DU = transform.Find("Collider_U").GetComponent<ColliderU>();

        C2DF = transform.Find("Collider_F").GetComponent<ColliderF>();

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

        collideF = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 fullColliderSize = C2DF.GetComponent<BoxCollider2D>().size;
        collideL = C2DL.CollisionL;
        collideR = C2DR.CollisionR;
        collideU = C2DU.CollisionU;
        collideD = C2DD.CollisionD;

        fullColliderSize.x = 0.56f;
        if(rc.height < 0.16f)
        {
            fullColliderSize.y = 0.56f + ((rc.height - 0.64f) * 1.024f);
        }
        else if (rc.height < 0.32f)
        {
            fullColliderSize.y = 0.56f + ((rc.height - 0.64f) * 0.512f);
        }
        else if (rc.height < 0.64f)
        {
            fullColliderSize.y = 0.56f + ((rc.height - 0.64f) * 0.256f);
        }
        else if (rc.height > 0.64f)
        {
            fullColliderSize.y = 0.56f + ((rc.height - 0.64f) * 0.064f);
        }

        if (rc.width < 0.16f)
        {
            fullColliderSize.x = 0.56f + ((rc.width - 0.64f) * 1.024f);
        }
        else if (rc.width < 0.32f)
        {
            fullColliderSize.x = 0.56f + ((rc.width - 0.64f) * 0.512f);
        }
        else if (rc.width < 0.64f)
        {
            fullColliderSize.x = 0.56f + ((rc.width - 0.64f) * 0.256f);
        }
        else if (rc.width > 0.64f)
        {
            fullColliderSize.x = 0.56f + ((rc.width - 0.64f) * 0.064f);
        }

        C2DF.GetComponent<BoxCollider2D>().size = fullColliderSize;

        //C2DF.GetComponent<BoxCollider2D>().size = new Vector2(rc.width*rc.width, rc.height*rc.height);

    }
}
