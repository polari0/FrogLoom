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
