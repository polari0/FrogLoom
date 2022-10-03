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
