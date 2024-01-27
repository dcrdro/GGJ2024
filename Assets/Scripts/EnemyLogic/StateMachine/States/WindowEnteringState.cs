using System.Numerics;
using EnemyLogic.UI;
using HouseLogic.Entrances;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace EnemyLogic.StateMachine.States
{
  public class WindowEnteringState : ExitableStateBase, IPayloadedState<Window, bool>
  {
    [SerializeField]
    private float _windowEnteringDelay;
    
    [SerializeField, HideInInspector]
    private EnemyStateMachine _stateMachine;

    [SerializeField, HideInInspector]
    private Timer _timer;

    [SerializeField, HideInInspector]
    private EnemyInterface _interface;

    [SerializeField, HideInInspector]
    private EnemyAnimator _animator;

    #region Properties

    private ActionProgressBar ActionProgressBar => _interface.ActionProgressBar;

    #endregion
    
    #region Fields

    private Window _window;
    private bool _isEscaping;

    #endregion

    public void Enter(Window window, bool isEscaping)
    {
      _isEscaping = isEscaping;
      _window = window;
      
      Vector3 targetPosition = _isEscaping ? _window.OutsidePoint : _window.InsidePoint;
      targetPosition.y = 0;
      transform.LookAt(targetPosition);
      
      _timer.Play(_windowEnteringDelay, OnWindowEnteringActionComplete, UpdateWindowEnteringProgress);
      
      UpdateWindowEnteringProgress();
      ActionProgressBar.Toggle(true);
      
      float climbOverSpeed = 1.667f / _windowEnteringDelay;
      _animator.LockAction(true);
      _animator.PlayClimbOver(climbOverSpeed);
    }

    public override void Exit()
    {
      base.Exit();
      
      _animator.LockAction(false);
      ActionProgressBar.Toggle(false);
      _timer.Stop();
    }

    private void OnWindowEnteringActionComplete()
    {
      Vector3 spawnPosition = _isEscaping ? _window.OutsidePoint : _window.InsidePoint;
      transform.position = spawnPosition;
      
      if(_isEscaping)
        _stateMachine.Enter<MoveToSpawnPointState>();
      else
        _stateMachine.Enter<MoveToJewelState>();
    }

    private void UpdateWindowEnteringProgress()
    {
      float percentage = _timer.CurrentTime / _timer.TargetTime;
      ActionProgressBar.SetValue(percentage);
      
      Vector3 from = _isEscaping ? _window.InsidePoint : _window.OutsidePoint;;
      Vector3 to = _isEscaping ? _window.OutsidePoint : _window.InsidePoint;
      Vector3 newPosition = Vector3.Lerp(from, to, _timer.NormalizedTime);
      newPosition.y = transform.position.y;
      transform.position = newPosition;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
      if (_stateMachine == null)
        TryGetComponent(out _stateMachine);

      if (_timer == null)
        TryGetComponent(out _timer);

      if (_interface == null)
        TryGetComponent(out _interface);

      if (_animator == null)
        TryGetComponent(out _animator);
    }
#endif
  }
}