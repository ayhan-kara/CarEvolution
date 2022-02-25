using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayButton : MonoBehaviour
{
    private void Awake()
    {
        DOTween.Sequence()
        .Append(transform.DOScale(new Vector3(1f, 1.2f, 1), 1f).SetEase(Ease.OutBack))
        .Append(transform.DOScale(new Vector3(1f, 1f, 1), 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo));
    }

}

