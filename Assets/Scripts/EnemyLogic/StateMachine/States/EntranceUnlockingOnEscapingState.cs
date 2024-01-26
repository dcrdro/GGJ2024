using HouseLogic.Entrances;

namespace EnemyLogic.StateMachine.States
{
  public class EntranceUnlockingOnEscapingState : EntranceUnlockingState
  {
    protected override void MoveToNextState()
    {
      if(Entrance is Window)
        StateMachine.Enter<WindowEnteringState, Window, bool>(Entrance as Window, true);
      else
        StateMachine.Enter<MoveToSpawnPointState>();
    }
  }
}