using Godot;
using System;

public partial class Player : CharacterBody2D
{
  private Sprite2D _sprite;
  private AnimationPlayer _animPlayer;
  private PhysicsComponent _physics;
  private PlayerController _controller;

  public override void _Ready()
  {
    _sprite = GetNode<Sprite2D>("Sprite");
    _animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    _physics = GetNode<PhysicsComponent>("PhysicsComponent");
    _controller = GetNode<PlayerController>("PlayerController");
  }

  public override void _PhysicsProcess(double delta)
  {

  }
}
