using Extensions;
using HouseLogic.Entrances;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public class MoveToHouseEntranceFromInsideState : MoveToHouseEntranceState
  {
    protected override EntranceBase GetTargetEntrance() => 
      NavMeshExtensions.FindClosestEntrance(transform.position, false);

    protected override void OnEntranceReached() => 
      StateMachine.Enter<EntranceUnlockingOnEscapingState, EntranceBase>(TargetEntrance);

    protected override Vector3 GetTargetPosition() => 
      TargetEntrance.InsidePoint;
  }
}