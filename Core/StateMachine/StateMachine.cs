using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass]
public partial class StateMachine : Node
{
  private Character _owner;
  private State _currentState;
  private Dictionary<Type, State> _states = new();

  public override void _Ready()
  {
    _owner = Owner as Character;

    foreach (Node child in GetChildren()) {
      if (child is State state) {
        _states[child.GetType()] = state;
      }
    }

    if (_states.Count > 0) {
      SwitchToState(_states.Values.First());
    }
  }

  public override void _Process(double delta)
  {
    _currentState?.Process(delta);
  }

  public void SwitchState<T>() where T : State
  {
    if (_states.TryGetValue(typeof(T), out var newState)) {
      SwitchToState(newState);
    } else {
      GD.PushWarning($"State of type '{typeof(T).Name}' not found.");
    }
  }

  public void SwitchToState(State state)
  {
    if (_currentState == state) return;

    _currentState?.Exit();
    _currentState = state;
    _currentState.Enter();
  }
}
