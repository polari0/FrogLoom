using UnityEngine;

namespace FrogLoom
{
    internal abstract class CharacterBaseState
    {
        private bool _isRootState = false;
        protected CharacterStateMachine _ctx;
        protected CharacterStateFactory _factory;
        protected CharacterBaseState _currentSubState;
        protected CharacterBaseState _currentSuperState;

        protected bool IsRootState { set { _isRootState = value; } }
        public CharacterStateMachine Ctx { get { return _ctx; } }
        public CharacterStateFactory Factory { get { return _factory; } }
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
            UpdateState();
            if (_currentSubState != null)
            {
                _currentSubState.UpdateStates();
            }
        }
        protected void SwitchStates(CharacterBaseState newState)
        {
            Debug.Log("Switching States");
            //Exit current State
            ExitState();

            //Enter new state
            newState.EnterState();

            /* Use only if using HFSM
            if (_isRootState)
            {
                // switch current state of context
                _ctx.CurrentState = newState;
            }
            else if (_currentSuperState != null)
            {
                // set the current super states sub state to the new state
                _currentSuperState.SetSubState(newState);
            }
            */
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