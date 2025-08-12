using Godot;

[GlobalClass]
public partial class IdleState : State
{
  public override void Enter()
  {
    GD.Print("Entering Idle state");
    AnimPlayer.Play("Idle");
    Controller.CanDoubleJump = true;
  }

  public override void Process(double delta)
  {
    if (!OwnerCharacter.IsOnFloor()) {
      StateMachine.SwitchState<FallingState>();
      return;
    }

    if (Controller.MoveDirection != 0) {
      StateMachine.SwitchState<RunState>();
    }

    if (Controller.WantsToJump) {
      StateMachine.SwitchState<JumpState>();
    }
  }
}
