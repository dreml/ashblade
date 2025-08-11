using Godot;
using System.Collections.Generic;

[GlobalClass]
public partial class StateMachine : Node
{
  private Character _owner;
  private State _currentState;
  private Dictionary<string, State> _states = new();

  public override void _Ready()
  {
    _owner = Owner as Character;

    foreach (Node child in GetChildren()) {
      if (child is State state) {
        _states[state.Name] = state;
      }
    }

    if (_states.Count > 0) {
      var first = _states.Values.GetEnumerator();
      first.MoveNext();
      SwitchToState(first.Current);
    }
  }

  public override void _Process(double delta)
  {
    _currentState?.Process(delta);
  }

  public void SwitchState(string stateName)
  {
    if (_states.TryGetValue(stateName + "State", out var newState)) {
      SwitchToState(newState);
    } else {
      GD.PushWarning($"State '{stateName}' not found.");
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
