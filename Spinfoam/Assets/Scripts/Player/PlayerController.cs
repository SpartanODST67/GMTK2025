using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] public float turnSpeedMultiplier = 1f;
    [SerializeField] float timeSpeedMultiplier = .5f;
    private float elapsedTime = 0;
    bool isMoving = false;
    bool isStarted = false;

    [SerializeField] PlayerInput playerInput;
    private InputAction turnAction;

    private void Awake()
    {
        turnAction = playerInput.actions["Move"];
    }

    // Update is called once per frame
    private void Update()
    {
        if(!isStarted && Starter.instance != null && Starter.instance.gameStarted == true)
        {
            isMoving = true;
            isStarted = true;
        }
        if (!isMoving) return;
        Turn();
    }

    void FixedUpdate()
    {
        if (!isMoving) return;
        transform.position += transform.up * ((speed + (elapsedTime * timeSpeedMultiplier)) * Time.deltaTime);
        elapsedTime += Time.deltaTime;
    }

    void Turn() 
    { 
        transform.Rotate(0, 0, -turnAction.ReadValue<Vector2>().x * turnSpeed * turnSpeedMultiplier * Time.deltaTime * (1/Time.timeScale));
    }
}
