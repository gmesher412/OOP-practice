using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    InputAction moveAction;
    public Vector3 MoveValue;
    InputAction screenPosition;
    public virtual Vector2 MousePosition {get; private set;}
    public virtual InputAction FireAction {get; private set;}

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        screenPosition = InputSystem.actions.FindAction("Look");
        FireAction = InputSystem.actions.FindAction("Attack");
    }

    void Update()
    {
        MoveValue = moveAction.ReadValue<Vector3>();
        MousePosition = screenPosition.ReadValue<Vector2>();
    }
}
