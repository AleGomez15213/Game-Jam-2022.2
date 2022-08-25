using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Scripts.InputSystem
{
    public class InputController : MonoBehaviour
    {
        internal delegate void UpAction();
        internal delegate void DownAction();
        internal delegate void LeftAction();
        internal delegate void RightAction();
        internal delegate void InteractAction();

        internal event UpAction OnUpTriggered = null;
        internal event DownAction OnDownTriggered = null;
        internal event LeftAction OnLeftTriggered = null;
        internal event RightAction OnRightTriggered = null;
        internal event InteractAction OnInteractTriggered = null;

        public PlayerInput _playerInput;

        [Header("Character Input Values")]
        public Vector2 move;
/*        public Vector2 look;
        public bool jump;
        public bool sprint;*/

        [Header("Movement Settings")]
        public bool analogMovement;

#if !UNITY_IOS || !UNITY_ANDROID
        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        //public bool cursorInputForLook = true;
#endif

        private void Start()
        {
            _playerInput = gameObject.GetComponent<PlayerInput>();
        }

        /*public void switchToPlayerInput()
        {
            _playerInput.SwitchCurrentActionMap(_playerInput.actions.FindActionMap("Player").name);
        }

        public void switchToGUIInput()
        {
            _playerInput.SwitchCurrentActionMap(_playerInput.actions.FindActionMap("GUI_Input").name);
        }*/

#if ENABLE_INPUT_SYSTEM 
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        /*public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }*/

        public void OnUp(InputValue value)
        {
            OnUpTriggered?.Invoke();
        }
        public void OnDown(InputValue value)
        {
            OnDownTriggered?.Invoke();
        }
        public void OnLeft(InputValue value)
        {
            OnLeftTriggered?.Invoke();
        }
        public void OnRight(InputValue value)
        {
            OnRightTriggered?.Invoke();
        }

        public void OnInteract(InputValue value)
        {
            OnInteractTriggered?.Invoke();
        }
#else
	// old input sys if we do decide to have it (most likely wont)...
#endif


        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

       /* public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }*/

#if !UNITY_IOS || !UNITY_ANDROID

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }

#endif

    }

}