using Godot;

[GlobalClass]
public partial class HealthComponent : Component
{
  [Signal]
  public delegate void DiedEventHandler();

  [Export]
  private int _maxHealth = 10;

  private int _currentHealth;

  public override void _Ready()
  {
    base._Ready();

    _currentHealth = _maxHealth;
  }

  public bool IsImmune = false;
  public bool IsDead => _currentHealth <= 0;

  public void TakeDamage(int amount)
  {
    if (IsImmune || IsDead) return;

    _currentHealth = Mathf.Clamp(_currentHealth - amount, 0, _maxHealth);

    GD.Print(Owner.Name + " has taken damage: " + amount + ", current health: " + _currentHealth);

    if (IsDead) {
      EmitSignal(SignalName.Died);
    }
  }
}
