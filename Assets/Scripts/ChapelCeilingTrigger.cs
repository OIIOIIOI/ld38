using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapelCeilingTrigger : Trigger
{

    public GameObject background;
    public GameObject[] otherColliders;
    public float bottomY;
    public float topY;
    public float acceleration;

    bool isLookingUp = false;
    CapsuleCollider2D colliderCapsule;

    new void Start ()
    {
        base.Start();
        colliderCapsule = gameObject.GetComponent<CapsuleCollider2D>();
    }

    override protected void CustomScript (Trigger trigger)
    {
        StartCoroutine("LookUpDown");
    }

    IEnumerator LookUpDown ()
    {
        if (colliderCapsule)
        {
            colliderCapsule.offset = new Vector2(0f, -colliderCapsule.offset.y);
            colliderCapsule.transform.Translate(0f, 100f, 0f);
        }
        
        float val = topY;

        if (!isLookingUp)
        {
            foreach (GameObject coll in otherColliders)
                coll.transform.Translate(0f, 100f, 0f);
        }
        else
        {
            val = bottomY;
        }

        while (Mathf.Abs(background.transform.position.y - val) > 0.01f)
        {
            float step = (val - background.transform.position.y) * acceleration;
            background.transform.Translate(0f, step, 0f);
            yield return new WaitForFixedUpdate();
        }
        background.transform.position = new Vector3(0f, val, 0f);

        colliderCapsule.transform.Translate(0f, -100f, 0f);
        isLookingUp = !isLookingUp;

        if (!isLookingUp)
        {
            foreach (GameObject coll in otherColliders)
                coll.transform.Translate(0f, -100f, 0f);
        }

        yield return null;
    }

}
