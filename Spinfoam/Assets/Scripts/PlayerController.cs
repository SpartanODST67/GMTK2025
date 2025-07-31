using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float turnSpeed = 5f;
    private bool turning = false;
    private float direction = 0;

    [SerializeField] PlayerInput playerInput;
    private InputAction turnAction;

    private void Awake()
    {
        turnAction = playerInput.actions["Move"];
    }

    private void OnEnable()
    {
        turnAction.performed += StartTurn;
    }

    private void OnDisable()
    {
        turnAction.performed -= StopTurn;
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void StartTurn(InputAction.CallbackContext context)
    {
        turning = true;
        direction = context.ReadValue<Vector2>().x;
        Debug.Log(direction);
    }

    void StopTurn(InputAction.CallbackContext context)
    {
        turning = false;
    }

    void Turn()
    {
        if (!turning) return;
        transform.Rotate(0, 0, -direction * turnSpeed * Time.deltaTime);
    }
}
