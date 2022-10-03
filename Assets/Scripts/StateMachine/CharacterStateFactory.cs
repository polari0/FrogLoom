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
            return new CharacterIdleState(_context, this);
        }
        internal CharacterBaseState Walk()
        {
            return new CharacterWalkState(_context, this);
        }
        internal CharacterBaseState Run()
        {
            return new CharacterRunState(_context, this);
        }
        internal CharacterBaseState Jump()
        {
            return new CharacterJumpState(_context, this);
        }
        internal CharacterBaseState Grounded()
        {
            return new CharacterGroundedState(_context, this);
        }
    } 
}
