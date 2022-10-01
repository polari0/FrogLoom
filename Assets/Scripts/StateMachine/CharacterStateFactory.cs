namespace FrogLoom
{
    internal class CharacterStateFactory
    {
        CharacterStateMachine _context;

        internal CharacterStateFactory(CharacterStateMachine currentContext)
        {
            _context = currentContext;
        }

        internal CharacterBaseState Idle()
        {
            return new CharacterIdleState();
        }
        internal CharacterBaseState Walk()
        {
            return new ChacterWalkState();
        }
        internal CharacterBaseState Run()
        {
            return new CharacterRunState();
        }
        internal CharacterBaseState Jump()
        {
            return new CharacterJumpState();
        }
        internal CharacterBaseState Grounded()
        {
            return new ChacterGroundedState();
        }
    } 
}
