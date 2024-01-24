using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public abstract class ExitableStateBase : MonoBehaviour, IExitableState
  {
    public virtual void Exit() { }
  }
}