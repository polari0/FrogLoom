using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogLoom
{
    internal class CharacterGroundedState : CharacterBaseState
    {
        public CharacterGroundedState(CharacterStateMachine currentContext, CharacterStateFactory characterStateFactory) : base(currentContext, characterStateFactory) { }
        internal override void EnterState()
        {
            Debug.Log("Enter Grounded State"); 
        }
        internal override void UpdateState()
        {
            //Debug.Log("Update is called");
            CheckSwitchStates();
        }
        internal override void ExitState()
        {

        }
        internal override void CheckSwitchStates()
        {
            if (Ctx.IsJumpPressed && !Ctx.RequireNewJumpPress && Ctx.IsGrounded)
            {
                SwitchStates(Factory.Jump());
            }
        }
        internal override void InitializeSubState()
        {

        }
    } 
}
