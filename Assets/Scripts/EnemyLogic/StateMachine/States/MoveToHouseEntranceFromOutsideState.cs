using Extensions;
using HouseLogic.Entrances;
using UnityEngine;

namespace EnemyLogic.StateMachine.States
{
  public class MoveToHouseEntranceFromOutsideState : MoveToHouseEntranceState
  {
    protected override EntranceBase GetTargetEntrance() => 
      NavMeshExtensions.FindClosestEntrance(transform.position, true);

    protected override void OnEntranceReached() => 
      StateMachine.Enter<EntranceUnlockingOnEnteringState, EntranceBase>(TargetEntrance);
    
    protected override Vector3 GetTargetPosition() => 
      TargetEntrance.OutsidePoint;
  }
}