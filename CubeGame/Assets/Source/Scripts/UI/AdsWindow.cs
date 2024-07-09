using UnityEngine;
using YG;

public class AdsWindow : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }

    private void Rewarded(int i)
    {
        gameObject.SetActive(false); 
        _timer.StartTimer();
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
