public class CharacterStateFactory
{
    CharacterStateMachine _context;

    public CharacterStateFactory(CharacterStateMachine currentContext)
    {
        _context = currentContext;
    }

    public CharacterBaseState Idle()
    {
        return new CharacterIdleState();
    }
    public CharacterBaseState Walk()
    {
        return new ChacterWalkState();
    }
    public CharacterBaseState Run()
    {
        return new CharacterRunState();
    }
    public CharacterBaseState Jump()
    {
        return new CharacterJumpState();
    }
    public CharacterBaseState Grounded()
    {
        return new ChacterGroundedState();
    }
}
