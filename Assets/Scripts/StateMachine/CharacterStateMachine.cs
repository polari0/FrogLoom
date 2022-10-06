using UnityEngine;
using UnityEngine.InputSystem;


//This entire script is the one that is used for controlling the character states and only one we need to be attached to the character. 
namespace FrogLoom
{
    internal class CharacterStateMachine : MonoBehaviour
    {
        //State variables
        CharacterStateFactory _states;
        CharacterBaseState _currentState;
        FrogLoomInput _playerInput;
        private Vector2 _currentMovementInput;
        private bool _isMovementPressed;
        private bool _isJumpPressed = false;
        private bool _isRunPressed;
        private float _zero = 0f;
        private Vector2 _appliedMovement;
        Transform _transform;

        [SerializeField] private float _jumpForce = 1f;
        [SerializeField] private float _movespeed = 1f;
        private bool _grounded;
        private CapsuleCollider2D _capsuleCollider2D;
        private Rigidbody2D _rigidBody;
        [SerializeField] private LayerMask _platformLayerMask;

        //getter and setters for variables We need to have one for each variable we use for the character controller. 
        internal CharacterBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }

        public Rigidbody2D PlayerRigidBody { get { return _rigidBody; } set { _rigidBody = value; } }
        public bool IsGrounded { get { return _grounded; } }
        public bool IsMovementPressed { get { return _isMovementPressed; } }
        public bool IsRunPressed { get { return _isRunPressed; } }
        public bool IsJumpPressed { get { return _isJumpPressed; } }
        public Vector2 AppliedMovement { get { return _appliedMovement; } set { _appliedMovement = value; } }
        public Vector2 CurrentMovementInput { get { return _currentMovementInput; } } 
        public Transform PlayerTransform { get { return _transform; } set { _transform = value; } }
        public float JumpForce { get { return _jumpForce; } }

        private void CheckGrounded ()
        {
            // How far the ray box extends from the character
            float extraHeight = 0.2f;
            RaycastHit2D raycastHit = Physics2D.BoxCast(_capsuleCollider2D.bounds.center, _capsuleCollider2D.bounds.size * 0.8f, 0f, Vector2.down, extraHeight, _platformLayerMask);

            // Set grounded status
            _grounded = raycastHit.collider != null;

            // Following lines are for debugging purposes only
            Color rayColor;
            if (raycastHit.collider != null)
            {
                rayColor = Color.green;
            } else
            {
                rayColor = Color.red;
            }
            // This helps to visualize where the box collider hits approximately
            // Not exactly correct!!
            Debug.DrawRay(_capsuleCollider2D.bounds.center + new Vector3(_capsuleCollider2D.bounds.extents.x * 0.8f, 0), Vector2.down * (_capsuleCollider2D.bounds.extents.y + extraHeight), rayColor);
            Debug.DrawRay(_capsuleCollider2D.bounds.center - new Vector3(_capsuleCollider2D.bounds.extents.x * 0.8f, 0), Vector2.down * (_capsuleCollider2D.bounds.extents.y + extraHeight), rayColor);
            Debug.DrawRay(_capsuleCollider2D.bounds.center - new Vector3(_capsuleCollider2D.bounds.extents.x, _capsuleCollider2D.bounds.extents.y + extraHeight), Vector2.right * (_capsuleCollider2D.bounds.size), rayColor);
            //Debug.Log(raycastHit.collider);
        }



        private void Awake()
        {
            // Initialize states
            _states = new CharacterStateFactory(this);
            _currentState = _states.Grounded();
            _currentState.EnterState();

            // Get player properties
            _capsuleCollider2D = transform.GetComponent<CapsuleCollider2D>();
            _rigidBody = transform.GetComponent<Rigidbody2D>();
            _transform = transform;

            _playerInput = new FrogLoomInput();
            // GetInput
            _playerInput.Player.Move.started += OnMove;
            _playerInput.Player.Move.canceled += OnMove;
            _playerInput.Player.Move.performed += OnMove;
            _playerInput.Player.Run.started += OnRun;
            _playerInput.Player.Run.canceled += OnRun;
            _playerInput.Player.Jump.started += OnJump;
            _playerInput.Player.Jump.canceled += OnJump;

        }
        private void Update()
        {
            CheckGrounded();
            _currentState.UpdateState();
            _rigidBody.velocity = new Vector2(_appliedMovement.x, _rigidBody.velocity.y);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _currentMovementInput = context.ReadValue<Vector2>();
            _isMovementPressed = _currentMovementInput.x != _zero || _currentMovementInput.y != _zero;
            Debug.Log("Movement Pressed");
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            _isJumpPressed = context.ReadValueAsButton();
            Debug.Log("Jump Pressed");
        }

        public void OnRun(InputAction.CallbackContext context)
        {
            _isRunPressed = context.ReadValueAsButton();
            Debug.Log("Run Pressed");
        }
    } 
}
