using Godot;

[GlobalClass]
public partial class JumpState : State
{
  public override void Enter()
  {
    // GD.Print("Entering Jump state");

    if (Controller.WantsToJump) {
      Physics.Jump();
      Controller.ConsumeJumpInput();
      // AnimPlayer.Play("Jump");
    }

    StateMachine.SwitchState<FallingState>();
  }

}
