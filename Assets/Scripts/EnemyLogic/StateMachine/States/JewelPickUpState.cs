using EnemyLogic.UI;
using JewelLogic;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public class JewelPickUpState : ExitableStateBase, IPayloadedState<Jewel>
  {
    [SerializeField]
    private float _jewelPickingUpDelay;

    [SerializeField, HideInInspector]
    private EnemyInterface _interface;

    [SerializeField, HideInInspector]
    private EnemyStateMachine _stateMachine;

    [SerializeField, HideInInspector]
    private Timer _timer;

    #region Fields

    private Jewel _jewel;

    #endregion

    public void Enter(Jewel jewel)
    {
      _jewel = jewel;
      
      _timer.Play(_jewelPickingUpDelay, PickUpJewel, UpdateProgressBar);
      
      UpdateProgressBar();
      _interface.ActionProgressBar.Toggle(true);
    }

    public override void Exit()
    {
      base.Exit();
      
      _timer.Stop();
      _interface.ActionProgressBar.Toggle(false);
    }

    private void PickUpJewel()
    {
      _jewel.PickUp();
      _stateMachine.Enter<EscapeFromHouseState>();
    }

    private void UpdateProgressBar()
    {
      float percentage = _timer.CurrentTime / _timer.TargetTime;
      _interface.ActionProgressBar.SetValue(percentage);
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