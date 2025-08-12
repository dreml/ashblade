using Godot;

[GlobalClass]
public partial class AttackState : State
{
  protected override bool CanAttack => false;

  public override void Enter()
  {
    // GD.Print("Entering Attack state");

    Controller.CanFlip = false;
    Controller.ConsumeAttackInput();
    AnimPlayer.Play("Attack");
    AnimPlayer.AnimationFinished += OnAnimationFinished;
  }

  public override void Exit()
  {
    Controller.CanFlip = true;
    AnimPlayer.AnimationFinished -= OnAnimationFinished;
  }

  private void OnAnimationFinished(StringName animName)
  {
    if (animName == "Attack") {
      if (!OwnerCharacter.IsOnFloor()) {
        StateMachine.SwitchState<FallingState>();
      } else {
        StateMachine.SwitchState<IdleState>();
      }
    }
  }
}
