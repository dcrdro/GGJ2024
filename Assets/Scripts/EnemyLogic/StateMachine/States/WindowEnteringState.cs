using EnemyLogic.UI;
using HouseLogic.Entrances;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public class WindowEnteringState : ExitableStateBase, IPayloadedState<Window>
  {
    [SerializeField]
    private float _windowEnteringDelay;
    
    [SerializeField, HideInInspector]
    private EnemyStateMachine _stateMachine;

    [SerializeField, HideInInspector]
    private Timer _timer;

    [SerializeField, HideInInspector]
    private EnemyInterface _interface;
    
    #region Properties

    private ActionProgressBar ActionProgressBar => _interface.ActionProgressBar;

    #endregion
    
    #region Fields

    private Window _window;

    #endregion

    public void Enter(Window window)
    {
      _window = window;
      
      _timer.Play(_windowEnteringDelay, OnWindowEnteringActionComplete, UpdateWindowEnteringProgress);
      
      UpdateWindowEnteringProgress();
      ActionProgressBar.Toggle(true);
    }

    public override void Exit()
    {
      base.Exit();
      
      ActionProgressBar.Toggle(false);
      _timer.Stop();
    }

    private void OnWindowEnteringActionComplete()
    {
      transform.position = _window.EnteringPoint.position;
      _stateMachine.Enter<MoveToJewelState>();
    }

    private void UpdateWindowEnteringProgress()
    {
      float percentage = _timer.CurrentTime / _timer.TargetTime;
      ActionProgressBar.SetValue(percentage);
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
    }
#endif
  }
}