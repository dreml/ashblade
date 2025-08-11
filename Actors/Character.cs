using Godot;

public partial class Character : CharacterBody2D, IDamageable
{
  protected HealthComponent HealthComponent { get; private set; }

  public override void _Ready()
  {
    base._Ready();

    HealthComponent = GetNode<HealthComponent>("HealthComponent");
  }

  public void TakeDamage(int amount)
  {
    HealthComponent?.TakeDamage(amount);
  }
}
