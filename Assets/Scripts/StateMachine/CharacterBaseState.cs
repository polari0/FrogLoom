using UnityEngine;

namespace FrogLoom
{
    internal abstract class CharacterBaseState
    {
        protected CharacterStateMachine _ctx;
        protected CharacterStateFactory _factory;
        protected CharacterBaseState _currentSubState;
        protected CharacterBaseState _currentSuperState;
        internal CharacterBaseState(CharacterStateMachine currentContext, CharacterStateFactory characterStateFactory)
        {
            _ctx = currentContext;
            _factory = characterStateFactory;
        }


        internal abstract void EnterState();
        internal abstract void UpdateState();
        internal abstract void ExitState();
        internal abstract void CheckSwitchStates();
        internal abstract void InitializeSubState();


        void UpdateStates()
        {

        }
        protected void SwitchStates(CharacterBaseState newState)
        {
            //Exit current State
            ExitState();

            //Enter new state
            newState.EnterState();

            //Switch Current state of context
            _ctx.CurrentState = newState;
        }
        protected void SetSuperState(CharacterBaseState newSuperState)
        {
            _currentSuperState = newSuperState;
        }
        protected void SetSubState(CharacterBaseState newSubState)
        {
            _currentSubState = newSubState;
            newSubState.SetSuperState(this);
        }

    } 
}