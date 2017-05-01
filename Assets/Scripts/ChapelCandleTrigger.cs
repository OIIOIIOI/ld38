using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChapelCandleTrigger : Trigger
{

    public Background anim;
    public GameObject numberTrigger;

    int animIndex = 0;

    new void Start ()
    {
        base.Start();

        numberTrigger.SetActive(false);
    }

    override public void CustomScript (Trigger trigger)
    {
        GetComponent<CircleCollider2D>().enabled = false;

        at.SfxBoard(1);

        anim.Swap(animIndex, 0.2f);
        Invoke("NextFrame", 1.5f);
    }

    void NextFrame ()
    {
        animIndex++;
        anim.Swap(animIndex, 0.2f);
        at.SfxBoard(2);

        if (animIndex < anim.alts.Length - 2)
            Invoke("NextFrame", Random.Range(0.3f, 0.4f));
        else if (animIndex == anim.alts.Length - 2)
            Invoke("FinalFrame", 1.5f);
    }

    void FinalFrame ()
    {
        animIndex++;
        anim.Swap(animIndex, 0.2f);
        at.SfxBoard(1);

        numberTrigger.SetActive(true);
    }

}
