using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{

    CharacterStateFactory _states;
    private void Awake()
    {
        _states = new CharacterStateFactory(this);
    }
}
