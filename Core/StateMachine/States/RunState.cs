using Godot;

[GlobalClass]
public partial class RunState : State
{
  public override void Enter()
  {
    GD.Print("Entering Run state");
    AnimPlayer.Play("Run");
  }

  public override void Exit() { }

  public override void Process(double delta)
  {
    if (Controller.MoveDirection == 0) {
      StateMachine.SwitchState("Idle");
    } else {
      Sprite.FlipH = Controller.MoveDirection < 0;
    }

    if (Controller.WantsToJump) {
      StateMachine.SwitchState("Jump");
    }
  }
}
