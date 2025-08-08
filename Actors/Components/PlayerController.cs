using Godot;
using System;

[GlobalClass]
public partial class PlayerController : Node
{
  [Export]
  private PhysicsComponent _physics;
  [Export]
  private StateMachine _stateMachine;
  [Export]
  private ulong JumpBufferMs = 150;

  public int MoveDirection { get; private set; }
  public bool WantsToJump => _jumpRequestTime != 0 && Time.GetTicksMsec() - _jumpRequestTime < JumpBufferMs;
  public bool CanMove = true;

  private CharacterBody2D _owner;
  private ulong _jumpRequestTime;

  public override void _Ready()
  {
    if (_physics == null) {
      GD.PrintErr("No PhysicsComponent in PlayerController");
    }
    if (_stateMachine == null) {
      GD.PrintErr("No StateMachine in PlayerController");
    }

    _owner = Owner as CharacterBody2D;
  }

  public override void _UnhandledInput(InputEvent @event)
  {
    if (!CanMove) return;

    if (Input.IsActionJustPressed("jump") && _owner.IsOnFloor()) {
      _jumpRequestTime = Time.GetTicksMsec();
      _stateMachine.SwitchState("Jump");
    }

    MoveDirection = (int)Input.GetAxis("left", "right");
    _physics.SetMoveDirection(MoveDirection);
  }

  public void ConsumeJumpInput()
  {
    _jumpRequestTime = 0;
  }
}
