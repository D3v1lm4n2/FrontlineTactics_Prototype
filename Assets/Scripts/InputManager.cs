using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerControls inputActions;

    public Vector2 MovementInput { get; private set; }

    private void Awake()
    {

        inputActions = new PlayerControls();


        inputActions.Player.Move.performed += ctx =>
        {
            MovementInput = ctx.ReadValue<Vector2>();
        };

        inputActions.Player.Move.canceled += ctx =>
        {
            MovementInput = Vector2.zero;
        };
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
