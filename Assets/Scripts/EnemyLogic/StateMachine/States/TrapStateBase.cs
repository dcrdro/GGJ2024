using System.Collections;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public abstract class TrapStateBase : ExitableStateBase, IPayloadedState<float>
  {
    [SerializeField]
    protected float _stanDuration;

    [SerializeField]
    protected GameObject _jewelObject;

    [SerializeField, HideInInspector]
    protected EnemyAnimator _animator;

    [SerializeField, HideInInspector]
    protected Timer _timer;

    [SerializeField, HideInInspector]
    protected EnemySharedState _sharedState;

    [SerializeField, HideInInspector]
    protected EnemyStateMachine _stateMachine;

    [SerializeField, HideInInspector]
    private EnemyHealth _health;

    public float soundDelay;
    public AudioClip clip;


    #region Fields

    protected Coroutine _coroutine;

    #endregion

    public void Enter(float damage)
    {
      _animator.LockAction(true);

      OnTrapStart();

      DropJewel();

      _timer.Play(_stanDuration, TrapHasExpired);
      StartCoroutine(Wait(soundDelay));

      _health.TakeDamage((int) damage);

      //_coroutine = StartCoroutine(ShowCamera());
    }


    IEnumerator Wait(float delay)
    {
      yield return new WaitForSeconds(delay);
      FindFirstObjectByType<AudioManager>().PlayAudio(clip, 1, true);
    }

    protected abstract void OnTrapStart();
    protected abstract void OnTrapEnd();

    private void DropJewel()
    {
            Vector3 offs = -transform.forward;
      offs = new Vector3(offs.x, 0, offs.y);

      var pos = transform.position + offs * 3f;
      _sharedState.Jewel?.Drop(pos);
      _sharedState.Jewel = null;
      _jewelObject.SetActive(false);
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
      FindFirstObjectByType<AudioManager>().Stop();

      sharedStateTrapCamera.enabled = false;
      trapRender.SetActive(false);
    }

    private void TrapHasExpired()
    {
      if(_health.IsDied)
        _stateMachine.Enter<MoveToHouseEntranceFromInsideState>();
      else
        _stateMachine.Enter<MoveToJewelState>();
    }

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

      if (_health == null)
        TryGetComponent(out _health);
    }
#endif
  }
}