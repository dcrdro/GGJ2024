﻿using EnemyLogic.UI;
using JewelLogic;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public class JewelPickUpState : ExitableStateBase, IPayloadedState<Jewel>
  {
    public EnemySharedState SharedState;

    [SerializeField]
    private float _jewelPickingUpDelay;

    [SerializeField]
    private GameObject _jewelObject;

    [SerializeField, HideInInspector]
    private EnemyInterface _interface;

    [SerializeField, HideInInspector]
    private EnemyAnimator _animator;

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
      SharedState.Jewel = jewel;

      _jewel.StartPickingUp();
      _timer.Play(_jewelPickingUpDelay, PickUpJewel, UpdateProgressBar);

      float pickUpSpeed = 2.046f / _jewelPickingUpDelay;
      _animator.PlayPickUp(pickUpSpeed);
      
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
      _jewel.PickUp(transform);
      _jewelObject.SetActive(true);
      _stateMachine.Enter<MoveToHouseEntranceFromInsideState>();
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

      if (_animator == null)
        TryGetComponent(out _animator);
    }
#endif
  }
}