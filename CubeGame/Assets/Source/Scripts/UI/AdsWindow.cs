using System;
using UnityEngine;
using YG;

public class AdsWindow : MonoBehaviour
{
    public Action OnContinue;
    
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }

    private void Rewarded(int i)
    {
        gameObject.SetActive(false); 
        OnContinue?.Invoke();
    }
    
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }

    public void OpenAds()
    {
        YandexGame.RewVideoShow(1);
    }
}
