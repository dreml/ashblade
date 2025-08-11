using Godot;

public abstract partial class State : Node
{
  protected Character OwnerCharacter { get; private set; }
  protected StateMachine StateMachine { get; private set; }
  protected AnimationPlayer AnimPlayer { get; private set; }
  protected Sprite2D Sprite { get; private set; }
  protected PhysicsComponent Physics { get; private set; }
  protected PlayerController Controller { get; private set; }

  public abstract void Enter();
  public abstract void Exit();
  public abstract void Process(double delta);

  public override void _Ready()
  {
    base._Ready();

    OwnerCharacter = Owner as Character;
    StateMachine = GetParent<StateMachine>();
    AnimPlayer = OwnerCharacter.GetNode<AnimationPlayer>("AnimationPlayer");
    Sprite = OwnerCharacter.GetNode<Sprite2D>("Sprite");
    Physics = OwnerCharacter.GetNode<PhysicsComponent>("PhysicsComponent");
    Controller = OwnerCharacter.GetNode<PlayerController>("PlayerController");
  }
}
