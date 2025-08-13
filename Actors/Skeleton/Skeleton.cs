public partial class Skeleton : Character
{
  public override void Flip(int moveDirection)
  {
    Sprite.FlipH = moveDirection < 0;
  }
}
