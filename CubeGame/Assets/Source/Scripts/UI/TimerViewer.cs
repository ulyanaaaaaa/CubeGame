using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Timer))]
public class TimerViewer : MonoBehaviour
{ 
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _bar;
    private Timer _timer;
    
    private void Awake()
    {
        _timer = GetComponent<Timer>();
        _timer.OnDurationChanged += UpdateView;
    }

    private void UpdateView(float currentDuration, float maxDuration)
    {
        float persent = currentDuration / maxDuration;
        _bar.fillAmount = persent;
        _bar.color = _gradient.Evaluate(persent);
    }
}
