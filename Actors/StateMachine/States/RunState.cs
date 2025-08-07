using Godot;

[GlobalClass]
public partial class RunState : State
{
  private PlayerController _controller;

  public override void _Ready()
  {
    base._Ready();

    _controller = _owner.GetNode<PlayerController>("PlayerController");
  }

  public override void Enter()
  {
    GD.Print("Entering Run state");
    _animPlayer.Play("Run");
  }

  public override void Exit() { }

  public override void Process(double delta)
  {
    if (!_controller.IsMoving()) {
      _stateMachine.SwitchState("Idle");
    }

    if (_controller.Direction != 0) {
      _sprite.FlipH = _controller.Direction < 0;
    }
  }
}
