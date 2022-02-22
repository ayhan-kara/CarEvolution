using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayButton : MonoBehaviour
{
    [SerializeField] Transform playButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DOTween.Sequence()
    .Append(playButton.transform.DOScale(new Vector3(1f, 1f, 1), 1f).SetEase(Ease.OutBack))
    .Append(playButton.transform.DOScale(new Vector3(1f, 1.5f, 1), 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo))
    .SetAutoKill(false);
    }
}
