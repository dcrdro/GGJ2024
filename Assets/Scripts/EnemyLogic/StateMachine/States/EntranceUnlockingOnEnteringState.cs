using HouseLogic.Entrances;

namespace EnemyLogic.StateMachine.States
{
  public class EntranceUnlockingOnEnteringState : EntranceUnlockingState
  {
    protected override void MoveToNextState()
    {
      if(Entrance is Window)
        StateMachine.Enter<WindowEnteringState, Window, bool>(Entrance as Window, false);
      else
        StateMachine.Enter<MoveToJewelState>();
    }
  }
}