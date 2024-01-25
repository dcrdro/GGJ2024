using EnemyLogic.UI;
using HouseLogic.Entrances;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public class EntranceUnlockingState : ExitableStateBase, IPayloadedState<EntranceBase>
  {
    [SerializeField]
    private float  _unlockingTime;
    
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

    private EntranceBase _entrance;

    #endregion

    public void Enter(EntranceBase entrance)
    {
      _entrance = entrance;
      
      if (entrance.IsUnlocked)
      {
        // NEED TO DEVELOP: play animation or place enemy inside house and after switch state;
        _stateMachine.Enter<MoveToJewelState>();
        return;
      }
      
      entrance.StartUnlocking();
      _timer.Play(_unlockingTime, OnUnlockingActionComplete, UpdateUnlockingProgress);

      UpdateUnlockingProgress();
      _interface.ActionProgressBar.Toggle(true);
    }

    public override void Exit()
    {
      base.Exit();
      
      _timer.Stop();
      ActionProgressBar.Toggle(false);
    }

    private void OnUnlockingActionComplete()
    {
      _entrance.Unlock();
      _stateMachine.Enter<MoveToJewelState>();
    }

    private void UpdateUnlockingProgress()
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