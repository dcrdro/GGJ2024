using UnityEngine;

namespace EnemyLogic.States
{
  public abstract class StateBase : MonoBehaviour, IExitableState
  {
    public void Exit() { }
  }
}