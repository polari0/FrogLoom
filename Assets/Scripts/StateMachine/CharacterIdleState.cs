using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogLoom
{
    internal class CharacterIdleState : CharacterBaseState
    {
        internal CharacterIdleState(CharacterStateMachine currentContext, CharacterStateFactory characterStateFactory) : base(currentContext, characterStateFactory){ }

        internal override void EnterState()
        {
            Debug.Log("Enter Idle State");
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

        }
        internal override void InitializeSubState()
        {

        }
    }

}