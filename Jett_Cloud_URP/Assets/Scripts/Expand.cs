using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Expand : MonoBehaviour
{
    [SerializeField] private float endScale;
    [SerializeField] private float startScale;
    [SerializeField] private float endDuration;
    [SerializeField] private float startDuration;
    [SerializeField] private float breakDuration;
    [SerializeField] private Ease endEaseType;
    [SerializeField] private Ease startEaseType;
    [SerializeField] private AnimationCurve shrinkEaseCurve;
    private Sequence mySequence = DOTween.Sequence();
    
    public void Grow()
    {
        StartCoroutine(GrowSequence());
    }

    private IEnumerator GrowSequence()
    {
        mySequence.Prepend(transform.DOScale(startScale, startDuration).SetEase(shrinkEaseCurve));
        yield return new WaitForSeconds(startDuration + breakDuration);
        mySequence.Append(transform.DOScale(endScale, endDuration).SetEase(endEaseType));
    }
}
