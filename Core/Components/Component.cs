using Godot;

public partial class Component : Node
{
  protected Character OwnerCharacter { get; private set; }

  public override void _Ready()
  {
    OwnerCharacter = Owner as Character;
  }
}
