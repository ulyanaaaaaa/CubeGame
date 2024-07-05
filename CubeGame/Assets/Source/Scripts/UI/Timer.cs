using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Action<float, float> OnDurationChanged;
    
    [SerializeField] private GridCheсker _gridCheсker;
    [SerializeField] private float _duration;
    private float _startDuration;
    private Coroutine _tick;
    
    private void Awake()
    {
        _startDuration = _duration;
        _tick = StartCoroutine(Tick());
    }

    private void OnEnable()
    {
        _gridCheсker.OnLoose += Restart;
        _gridCheсker.OnWin += Restart;
    }
    
    private void OnDisable()
    {
        _gridCheсker.OnLoose -= Restart;
        _gridCheсker.OnWin -= Restart;
    }

    private void Restart()
    {
        _duration = _startDuration;
        StopCoroutine(_tick);
        _tick = StartCoroutine(Tick());
    }
    
    private IEnumerator Tick()
    {
        while (_duration > 0)
        {
            yield return new WaitForSeconds(0.01f);
            _duration -= 0.01f;
            OnDurationChanged?.Invoke(_duration, _startDuration);
        }
        
        _gridCheсker.CheckGrid();
        
    }
}
