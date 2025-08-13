using Godot;

public partial class Player : Character
{
  [Export]
  private int _damage = 1;

  private Area2D _hitbox;
  private Camera2D _camera;

  private Vector2 _hitboxOriginalPosition;
  private float _hitboxOriginalRotation;

  public override void _Ready()
  {
    base._Ready();
    _hitbox = GetNode<Area2D>("HitBox");
    _hitboxOriginalPosition = _hitbox.Position;
    _hitboxOriginalRotation = _hitbox.Rotation;
  }

  public override void Flip(int moveDirection)
  {
    Sprite.FlipH = moveDirection < 0;
    _hitbox.Position = new Vector2(Mathf.Sign(moveDirection) * _hitboxOriginalPosition.X, _hitboxOriginalPosition.Y);
    _hitbox.Rotation = Mathf.Sign(moveDirection) * _hitboxOriginalRotation;
  }

  public void OnHitBoxBodyEntered(Node2D body)
  {
    if (!body.IsInGroup("enemy")) {
      return;
    }

    var enemy = body as Character;
    enemy?.TakeDamage(_damage);
  }
}
