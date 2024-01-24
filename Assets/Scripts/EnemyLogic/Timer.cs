using System;
using UnityEngine;

namespace EnemyLogic
{
  public class Timer : MonoBehaviour
  {
    #region Properties

    public float TargetTime => _time;
    public float CurrentTime
    {
      get => _currentTime;
      private set
      {
        _currentTime = value;
        _onTimerUpdated?.Invoke();
      }
    }

    #endregion
    
    #region Fields

    private Action _onComplete;
    private Action _onTimerUpdated;

    private bool _isLaunched;
    
    private float _time;
    private float _currentTime;
    
    #endregion
    
    public void Play(float time, Action onComplete = null, Action onTimerUpdated = null)
    {
      _onTimerUpdated = onTimerUpdated;
      _onComplete = onComplete;
      
      _time = time;
      CurrentTime = 0;
      
      _isLaunched = true;
    }

    public void Stop()
    {
      _isLaunched = false;

      _onTimerUpdated = null;
      _onComplete = null;
    }

    private void Update()
    {
      if(!_isLaunched)
        return;

      CurrentTime += Time.deltaTime;
      if (IsTimeExceeded())
        _onComplete?.Invoke();
    }

    private bool IsTimeExceeded() => 
      CurrentTime >= _time;
  }
}