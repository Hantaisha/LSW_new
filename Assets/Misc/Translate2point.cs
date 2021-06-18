using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Translate2point : MonoBehaviour
{
    public Transform start;
    public Transform end;

    public void RevealPopUp()
    {
        StopAllCoroutines();
        transform.DOLocalMove(end.localPosition, 20f * Time.deltaTime).SetEase(Ease.InOutElastic);
        StartCoroutine("Recede");
    }

    IEnumerator Recede()
    {
        yield return new WaitForSeconds(3f);
        transform.DOLocalMove(start.localPosition, 50f * Time.deltaTime).SetEase(Ease.InOutElastic);
    }
    

}
