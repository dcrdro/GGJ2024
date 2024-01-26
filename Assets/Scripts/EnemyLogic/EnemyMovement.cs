using System;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyLogic
{
  [RequireComponent(typeof(NavMeshAgent))]
  public class EnemyMovement : MonoBehaviour
  {
    [SerializeField, HideInInspector]
    private NavMeshAgent _agent;

    [SerializeField, HideInInspector]
    private EnemyAnimator _animator;

    #region Actions

    public event Action OnTargetReached; 

    #endregion
    
    public void SetTarget(Vector3 position) => 
      _agent.SetDestination(position);

    public void ToggleMovement(bool state)
    {
      _animator.ToggleMovement(state);
      
      if(enabled == state)
        return;
      
      _agent.isStopped = !state;
      enabled = state;
    }
    
    private void Update()
    {
      if (_agent.remainingDistance <= 0.2f) 
        OnTargetReached?.Invoke();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
      if (_agent == null)
        TryGetComponent(out _agent);

      if (_animator == null)
        TryGetComponent(out _animator);
    }
#endif
  }
}