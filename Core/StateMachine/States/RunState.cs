using Godot;

[GlobalClass]
public partial class RunState : State
{
  public override void Enter()
  {
    GD.Print("Entering Run state");
    AnimPlayer.Play("Run");
    Controller.CanDoubleJump = true;
  }

  public override void Process(double delta)
  {
    if (!OwnerCharacter.IsOnFloor()) {
      StateMachine.SwitchState<FallingState>();
      return;
    }

    if (Controller.MoveDirection == 0) {
      StateMachine.SwitchState<IdleState>();
    } else {
      Sprite.FlipH = Controller.MoveDirection < 0;
    }

    if (Controller.WantsToJump) {
      StateMachine.SwitchState<JumpState>();
    }
  }
}
