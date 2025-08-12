using Godot;

[GlobalClass]
public abstract partial class BaseController : Component
{
  [Export]
  protected PhysicsComponent Physics { get; private set; }
  [Export]
  protected StateMachine StateMachine { get; private set; }
  [Export]
  protected ulong JumpBufferMs = 150;

  public int MoveDirection { get; protected set; }
  public bool CanMove { get; set; } = true;
  public bool CanDoubleJump { get; set; } = true;
  public bool WantsToJump => _jumpRequestTime != 0 && Time.GetTicksMsec() - _jumpRequestTime < JumpBufferMs;

  protected ulong _jumpRequestTime;

  public override void _Ready()
  {
    base._Ready();

    if (Physics == null) {
      GD.PrintErr("No PhysicsComponent in BaseController");
    }
    if (StateMachine == null) {
      GD.PrintErr("No StateMachine in BaseController");
    }
  }

  public void ConsumeJumpInput()
  {
    _jumpRequestTime = 0;
  }
}
