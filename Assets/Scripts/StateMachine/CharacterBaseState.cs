using UnityEngine;

namespace FrogLoom
{
    public abstract class CharacterBaseState
    {
        internal abstract void EnterState();
        internal abstract void UpdateState();
        internal abstract void ExitState();
        internal abstract void CheckSwitchStates();
        internal abstract void InitializeSubState();


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
}