
using UnityEngine;

public abstract class CharacterBaseState
{
    public abstract void EnterState(CharacterStateMachine character);
    public abstract void UpdateState(CharacterStateMachine character);
    public abstract void OnCollisionEnter(CharacterStateMachine character);
}
