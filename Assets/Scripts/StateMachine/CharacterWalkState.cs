using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogLoom
{
    internal class CharacterWalkState : CharacterBaseState
    {
        internal CharacterWalkState(CharacterStateMachine currentContext, CharacterStateFactory characterStateFactory) : base (currentContext, characterStateFactory){ }
        internal override void EnterState()
        {
            Debug.Log("Enter Walk State");
        }
        internal override void UpdateState()
        {
            Ctx.AppliedMovement = Ctx.CurrentMovementInput;
            CheckSwitchStates();
        }
        internal override void ExitState()
        {

        }
        internal override void CheckSwitchStates()
        {
            if (!Ctx.IsMovementPressed)
            {
                SwitchStates(Factory.Idle());
            }
            else if (Ctx.IsMovementPressed && Ctx.IsRunPressed)
            {
                SwitchStates(Factory.Run());
            }
        }
        internal override void InitializeSubState()
        {

        }
    } 
}
