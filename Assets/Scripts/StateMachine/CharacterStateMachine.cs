using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    CharacterBaseState currentState;
    MovingState MovingState = new MovingState();
    JumpingState jumpingState = new JumpingState();
    IdleState idleState = new IdleState();
}
