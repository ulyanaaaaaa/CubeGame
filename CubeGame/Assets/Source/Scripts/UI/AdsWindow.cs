using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class AdsWindow : MonoBehaviour
{
    public Action OnContinue;
    [SerializeField] private int _lifeTime;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameButtons _gameButton;
    private Coroutine _lifeTick;
    
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
        StartTimer();
    }
    
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
        StopTimer();
    }

    private void StartTimer()
    {
        _lifeTick = StartCoroutine(LifeTick());
    }
    
    public void OpenAds()
    {
        YandexGame.RewVideoShow(1);
        StopTimer();
    }

    private void StopTimer()
    {
        if (_lifeTick != null)
            StopCoroutine(_lifeTick);
    }

    private void Rewarded(int i)
    {
        gameObject.SetActive(false); 
        OnContinue?.Invoke();
    }

    private IEnumerator LifeTick()
    {
        for (int i = 0; i < _lifeTime; i++)
        {
            _text.text = (_lifeTime - i).ToString();
            yield return new WaitForSeconds(1);
        }
        _gameButton.Exit();
    }
}
