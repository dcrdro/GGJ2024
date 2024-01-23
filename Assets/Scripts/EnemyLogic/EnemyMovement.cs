﻿using UnityEngine;
using UnityEngine.AI;

namespace EnemyLogic
{
  [RequireComponent(typeof(NavMeshAgent))]
  public class EnemyMovement : MonoBehaviour
  {
    [SerializeField, HideInInspector]
    private NavMeshAgent _agent;

    public void SetTarget(Vector3 position) => 
      _agent.SetDestination(position);

#if UNITY_EDITOR
    private void OnValidate()
    {
      if (_agent == null)
        TryGetComponent(out _agent);
    }
#endif
  }
}