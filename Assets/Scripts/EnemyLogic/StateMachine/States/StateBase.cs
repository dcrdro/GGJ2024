using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public abstract class StateBase : MonoBehaviour, IExitableState
  {
    public void Exit() { }
  }
}