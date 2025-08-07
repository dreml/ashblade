using Godot;

[GlobalClass]
public partial class IdleState : State
{
  public override void Enter()
  {
    GD.Print("Entering Idle state");
    _animPlayer.Play("Idle");
  }

  public override void Exit() { }

  public override void Process(double delta)
  {
  }
}
