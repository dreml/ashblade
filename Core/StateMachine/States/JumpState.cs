using Godot;

[GlobalClass]
public partial class JumpState : State
{
  public override void Enter()
  {
    GD.Print("Entering Jump state");
    if (!Controller.WantsToJump) return;

    Physics.Jump();
    Controller.ConsumeJumpInput();
  }

  public override void Exit() { }

  public override void Process(double delta)
  {
    var isMoving = Controller.MoveDirection != 0;

    if (OwnerCharacter.IsOnFloor()) {
      StateMachine.SwitchState(isMoving ? "Run" : "Idle");
    }

    if (isMoving) {
      Sprite.FlipH = Controller.MoveDirection < 0;
    }
  }
}