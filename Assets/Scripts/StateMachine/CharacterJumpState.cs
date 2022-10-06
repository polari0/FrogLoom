using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogLoom
{
    internal class CharacterJumpState : CharacterBaseState
    {
        internal CharacterJumpState(CharacterStateMachine currentContext, CharacterStateFactory characterStateFactory) : base(currentContext, characterStateFactory) { }
        internal override void EnterState()
        {
            Debug.Log("Enter Jump State");
            Jump();
        }
        internal override void UpdateState()
        {
            CheckSwitchStates();
        }
        internal override void ExitState()
        {
            Ctx.RequireNewJumpPress = true;
        }
        internal override void CheckSwitchStates()
        {
            Debug.Log(Ctx.IsGrounded);
            if (Ctx.IsGrounded)
            {
                SwitchStates(Factory.Grounded());
            }
        }
        internal override void InitializeSubState()
        {

        }

        void Jump() {
            Ctx.PlayerRigidBody.velocity = Vector2.up * Ctx.JumpForce;
        }
    }

}