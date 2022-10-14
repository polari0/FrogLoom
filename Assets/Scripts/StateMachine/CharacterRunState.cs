using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogLoom
{
    internal class CharacterRunState : CharacterBaseState
    {
        internal CharacterRunState(CharacterStateMachine currentContext, CharacterStateFactory characterStateFactory) : base(currentContext, characterStateFactory) { }
        internal override void EnterState()
        {
            Debug.Log("Enter Run State");
            _ctx.MoveSpeed = 5;

        }
        internal override void UpdateState()
        {
            CheckSwitchStates();
        }
        internal override void ExitState()
        {

        }
        internal override void CheckSwitchStates()
        {
            if (!_ctx.IsRunPressed)
            {
                SwitchStates(Factory.Walk());
            }
            else if (!_ctx.IsMovementPressed && !_ctx.IsRunPressed)
            {
                SwitchStates(Factory.Idle());
            }
        }
        internal override void InitializeSubState()
        {

        }
    } 
}
