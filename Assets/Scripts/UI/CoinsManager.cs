using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CoinsManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text coinUiText;
    [SerializeField] GameObject animatedCoinPrefab;
    [SerializeField] Transform target;

    [Space]
    [Header("Max Coins")]
    [SerializeField] int maxCoins;
    Queue<GameObject> coinsQueue = new Queue<GameObject>();

    [Space]
    [Header("Animation Settings")]
    [SerializeField][Range(0.1f, 3f)] float minAnimDuration;
    [SerializeField][Range(3f, 8f)] float maxAnimDuration;
    [SerializeField] Ease easeType;

    private int c = 0;
    Vector3 targetPos;

    private void Awake()
    {
        targetPos = target.position;
        PrepareCoins();
    }

    public int Coins
    {
        get { return c; }
        set { c = value; coinUiText.text = Coins.ToString(); }
    }
    void PrepareCoins()
    {
        GameObject coin;
        for (int i = 0; i < maxCoins; i++)
        {
            coin = Instantiate(animatedCoinPrefab);
            coin.transform.parent = transform;
            coin.SetActive(false);
            coinsQueue.Enqueue(coin);
        }
    }

    void Animate(Vector3 collectedCoinPos, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (coinsQueue.Count > 0)
            {
                GameObject coin = coinsQueue.Dequeue();
                coin.SetActive(true);
                coin.transform.position = collectedCoinPos;
                float duration = Random.Range(minAnimDuration, maxAnimDuration);
                coin.transform.DOMove(targetPos, duration)
                    .SetEase(easeType)
                    .OnComplete(() => { 
                        coin.SetActive(false); 
                        Coins++; });
            }
        }
        
    }

    public void AddCoins(Vector3 collectedCoinPos, int amount)
    {
        Animate(collectedCoinPos, amount);
    }
}
