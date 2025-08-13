using Godot;

public abstract partial class Character : CharacterBody2D, IDamageable
{
  protected HealthComponent HealthComponent { get; private set; }

  protected Sprite2D Sprite;

  public abstract void Flip(int moveDirection);

  public override void _Ready()
  {
    base._Ready();

    Sprite = GetNode<Sprite2D>("Sprite");

    HealthComponent = GetNode<HealthComponent>("HealthComponent");
  }

  public void TakeDamage(int amount)
  {
    HealthComponent?.TakeDamage(amount);
  }
}
