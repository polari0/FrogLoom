using UnityEngine;

public abstract class CharacterBaseState
{
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchStates();
    public abstract void InitializeSubState();


    void UpdateStates()
    {

    }
    void SwitchStates()
    {

    }
    void SetSuperState()
    {

    }
    void SetSubState()
    {

    }

}