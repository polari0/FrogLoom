using UnityEngine;


//This entire script is the one that is used for controlling the character states and only one we need to be attached to the character. 
namespace FrogLoom
{
    internal class CharacterStateMachine : MonoBehaviour
    {
        //State variables
        CharacterStateFactory _states;
        CharacterBaseState _currentState;

        //getter and setters for variables We need to have one for each variable we use for the character controller. 
        internal CharacterBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }


        private void Awake()
        {
            _states = new CharacterStateFactory(this);
            _currentState = _states.Grounded();
            _currentState.EnterState();

        }
        private void Update()
        {
            _currentState.UpdateState();
        }

    } 
}
