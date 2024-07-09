using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Action<float, float> OnDurationChanged;
    
    [SerializeField] private GridCheсker _gridCheсker;
    [SerializeField] private GameButtons _gameButtons;
    [SerializeField] private float _duration;
    private Coroutine _tick;
    [SerializeField] private float _startDuration;

    private void OnEnable()
    {
        _gridCheсker.OnLoose += StopTimer;
        _gridCheсker.OnWin += Restart;
        _gameButtons.OnPlay += StartTimer;
        _gameButtons.OnExit += StopTimer;
    }
    
    private void OnDisable()
    {
        _gridCheсker.OnLoose -= StopTimer;
        _gridCheсker.OnWin -= Restart;
        _gameButtons.OnPlay -= StartTimer;
        _gameButtons.OnExit -= StopTimer;
    }

    public void StartTimer()
    {
        if (_tick != null)
            StopCoroutine(_tick);
        
        _startDuration = _duration;
        _tick = StartCoroutine(Tick());
    }

    private void StopTimer()
    {
        if (_tick != null)
            StopCoroutine(_tick);
    }

    private void Restart()
    {
        _startDuration = _duration;
        
        if (_tick != null)
            StopCoroutine(_tick);
        
        _tick = StartCoroutine(Tick());
    }
    
    private IEnumerator Tick()
    {
        while (_startDuration > 0)
        {
            yield return new WaitForSeconds(0.1f);
            _startDuration -= 0.1f;
            OnDurationChanged?.Invoke(_startDuration, _duration);
        }
        _gridCheсker.CheckGrid();
    }
}
