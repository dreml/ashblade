using Godot;

public abstract partial class State : Node
{
  protected Character OwnerCharacter { get; private set; }
  protected StateMachine StateMachine { get; private set; }
  protected AnimationPlayer AnimPlayer { get; private set; }
  protected Sprite2D Sprite { get; private set; }
  protected PhysicsComponent Physics { get; private set; }
  protected BaseController Controller { get; private set; }

  protected virtual bool CanAttack => true;

  public virtual void Enter() { }
  public virtual void Exit() { }
  public virtual void Process(double delta)
  {
    if (CanAttack && Controller.WantsToAttack) {
      StateMachine.SwitchState<AttackState>();
    }
  }

  public override void _Ready()
  {
    base._Ready();

    OwnerCharacter = Owner as Character;
    StateMachine = GetParent<StateMachine>();
    AnimPlayer = OwnerCharacter.GetNode<AnimationPlayer>("AnimationPlayer");
    Sprite = OwnerCharacter.GetNode<Sprite2D>("Sprite");
    Physics = OwnerCharacter.GetNode<PhysicsComponent>("PhysicsComponent");
    Controller = OwnerCharacter.GetNode<BaseController>("Controller");
  }
}
