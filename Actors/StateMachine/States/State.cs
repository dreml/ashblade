using Godot;

public abstract partial class State : Node
{
  protected StateMachine _stateMachine;
  protected CharacterBody2D _owner;
  protected AnimationPlayer _animPlayer;
  protected Sprite2D _sprite;
  protected PhysicsComponent _physics;

  public virtual void Enter() { }
  public virtual void Exit() { }
  public virtual void Process(double delta) { }

  public override void _Ready()
  {
    _owner = Owner as CharacterBody2D;
    _stateMachine = GetParent<StateMachine>();
    _animPlayer = Owner.GetNode<AnimationPlayer>("AnimationPlayer");
    _sprite = Owner.GetNode<Sprite2D>("Sprite");
    _physics = Owner.GetNode<PhysicsComponent>("PhysicsComponent");
  }

}
