using Godot;

[GlobalClass]
public partial class FallingState : State
{
  public override void Enter()
  {
    // GD.Print("Entering Falling state");
    // AnimPlayer.Play("Falling");
  }

  public override void Process(double delta)
  {
    base.Process(delta);

    if (OwnerCharacter.IsOnFloor()) {
      bool isMoving = Controller.MoveDirection != 0;
      if (isMoving) {
        StateMachine.SwitchState<RunState>();
      } else {
        StateMachine.SwitchState<IdleState>();
      }
      return;
    }

    if (Controller.WantsToJump && Controller.CanDoubleJump) {
      Controller.CanDoubleJump = false;
      StateMachine.SwitchState<JumpState>();
    }
  }
}

