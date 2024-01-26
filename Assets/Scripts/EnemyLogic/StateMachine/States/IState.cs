namespace EnemyLogic.StateMachine.States
{
  public interface IState : IExitableState
  {
    void Enter();
  }

  public interface IPayloadedState<TPayload> : IExitableState
  {
    void Enter(TPayload payload);
  }

  public interface IPayloadedState<TPayLoad, FPayload> : IExitableState
  {
    void Enter(TPayLoad payLoad, FPayload payload1);
  }

  public interface IExitableState
  {
    void Exit();
  }
}