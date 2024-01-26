using System.Collections;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public class FireTrapState : ExitableStateBase, IState
  {
    [SerializeField]
    private float _stanDuration;

    [SerializeField]
    private GameObject _fireEffectObject;
    
    [SerializeField, HideInInspector]
    private EnemyAnimator _animator;

    [SerializeField, HideInInspector]
    private Timer _timer;

    [SerializeField, HideInInspector]
    private EnemySharedState _sharedState;

    [SerializeField, HideInInspector]
    private EnemyStateMachine _stateMachine;

    #region Fields

    private Coroutine _coroutine;

    #endregion
    
    public void Enter()
    {
      _animator.PlayOnFireTrap();
      _animator.LockAction(true);

      ToggleFireEffect(true);
      DropJewel();
      
      _timer.Play(_stanDuration, TrapHasExpired);
      _coroutine = StartCoroutine(ShowCamera());
    }

    private void DropJewel()
    {
      _sharedState.Jewel?.Drop();
      _sharedState.Jewel = null;
      throw new System.NotImplementedException();
    }

    public override void Exit()
    {
      base.Exit();
      
      ToggleFireEffect(false);
      _animator.LockAction(false);
      StopCoroutine(_coroutine);
    }

    private void TrapHasExpired() => 
      _stateMachine.Enter<MoveToJewelState>();

    private void ToggleFireEffect(bool state) => 
      _fireEffectObject.SetActive(state);
    
    private IEnumerator ShowCamera()
    {
      Camera sharedStateTrapCamera = _sharedState.TrapCamera;
      GameObject trapRender = FindObjectOfType<UIManager>().trapRender;

      trapRender.SetActive(true);
      sharedStateTrapCamera.enabled = true;
      yield return new WaitForSeconds(_stanDuration);
      sharedStateTrapCamera.enabled = false;
      trapRender.SetActive(false);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
      if (_animator == null)
        TryGetComponent(out _animator);

      if (_sharedState == null)
        TryGetComponent(out _sharedState);

      if (_stateMachine == null)
        TryGetComponent(out _stateMachine);
    }
#endif
  }
}