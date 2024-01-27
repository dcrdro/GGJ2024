using System.Collections;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public abstract class TrapStateBase : ExitableStateBase, IState
  {
    [SerializeField]
        protected float _stanDuration;

    [SerializeField, HideInInspector]
        protected EnemyAnimator _animator;

    [SerializeField, HideInInspector]
        protected Timer _timer;

    [SerializeField, HideInInspector]
        protected EnemySharedState _sharedState;

    [SerializeField, HideInInspector]
        protected EnemyStateMachine _stateMachine;

        #region Fields

        protected Coroutine _coroutine;

    #endregion
    
    public void Enter()
    {
      _animator.LockAction(true);
      
            OnTrapStart();

      DropJewel();
      
      _timer.Play(_stanDuration, TrapHasExpired);
      //_coroutine = StartCoroutine(ShowCamera());
    }

        protected abstract void OnTrapStart();
        protected abstract void OnTrapEnd();

    private void DropJewel()
    {
            Vector3 offs = Random.insideUnitCircle.normalized;
            offs = new Vector3(offs.x, 0, offs.y);
            var pos = transform.position + offs * 1.5f;
      _sharedState.Jewel?.Drop(pos);
      _sharedState.Jewel = null;
    }

    public override void Exit()
    {
      base.Exit();
      
            OnTrapEnd();

            _timer.Stop();
      _animator.LockAction(false);
      //StopCoroutine(_coroutine);

            Camera sharedStateTrapCamera = _sharedState.TrapCamera;
            GameObject trapRender = FindObjectOfType<UIManager>().trapRender;

            sharedStateTrapCamera.enabled = false;
            trapRender.SetActive(false);
        }

    private void TrapHasExpired() => 
      _stateMachine.Enter<MoveToJewelState>();

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
      
    if (_timer == null)
        TryGetComponent(out _timer);
    }
#endif
  }
}