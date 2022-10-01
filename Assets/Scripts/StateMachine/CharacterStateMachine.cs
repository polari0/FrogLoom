using UnityEngine;

namespace FrogLoom
{
    internal class CharacterStateMachine : MonoBehaviour
    {

        CharacterStateFactory _states;
        private void Awake()
        {
            _states = new CharacterStateFactory(this);
        }
    } 
}
