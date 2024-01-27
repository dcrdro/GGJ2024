using System;
using System.Collections.Generic;
using EnemyLogic.StateMachine.States;
using UnityEngine;

namespace EnemyLogic.StateMachine
{
  public class EnemyStateMachine : MonoBehaviour
  {
    [SerializeField]
    private ExitableStateBase[] _notBakedStates;
    
    #region Fields
    
    private Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    #endregion

    private void Awake()
    {
      _states = new Dictionary<Type, IExitableState>();

      foreach (ExitableStateBase state in _notBakedStates) 
        AddState(state.GetType(), state);
      
      Enter<MoveToHouseEntranceFromOutsideState>();
    }

    private void OnDestroy() => 
      _activeState.Exit();

    public void AddState(Type stateType, IExitableState state) => 
      _states.Add(stateType, state);

    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
    {
      TState state = ChangeState<TState>();
            state.Enter(payload);
    }
    
    public void Enter<TState, TPayload, FPayload>(TPayload payload, FPayload payload1) where TState : class, IPayloadedState<TPayload, FPayload>
    {
      TState state = ChangeState<TState>();
            state.Enter(payload, payload1);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
            Debug.Log($"switch state from {_activeState?.GetType().Name} to {typeof(TState).Name}", this);

            _activeState?.Exit();

      TState state = GetState<TState>();
      _activeState = state;
      
      return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState =>
      _states[typeof(TState)] as TState;
  }
}