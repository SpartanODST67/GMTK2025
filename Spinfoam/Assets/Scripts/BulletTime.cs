using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletTime : MonoBehaviour
{
    [SerializeField] float maxBulletTime = 60f;
    float bulletTime;
    [SerializeField] float bulletTimeGrowth = .5f;
    [SerializeField] float bulletTimePower = .5f;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] PlayerController playerController;
    [SerializeField] float turnSpeedMultiplier = 4f;
    [SerializeField] StatusBar bulletTimeBar;

    InputAction bulletTimeAction;
    InputAction bulletTimeAltAction;
    Coroutine currentRoutine;

    private void Awake()
    {
        bulletTime = maxBulletTime;
        bulletTimeAction = playerInput.actions["Sprint"];
        bulletTimeAltAction = playerInput.actions["Attack"];
    }

    private void OnEnable()
    {
        bulletTimeAction.performed += StartBulletTime;
        bulletTimeAction.canceled += StopBulletTime;
        bulletTimeAltAction.performed += StartBulletTime;
        bulletTimeAltAction.canceled += StopBulletTime;
    }

    private void OnDisable()
    {
        bulletTimeAction.performed -= StartBulletTime;
        bulletTimeAction.canceled -= StopBulletTime;
        bulletTimeAltAction.performed -= StartBulletTime;
        bulletTimeAltAction.canceled -= StopBulletTime;
    }

    private void StartBulletTime(InputAction.CallbackContext context)
    {
        Time.timeScale = bulletTimePower;
        if(currentRoutine != null) StopCoroutine(currentRoutine);
        playerController.turnSpeedMultiplier = turnSpeedMultiplier;
        currentRoutine = StartCoroutine(BulletTimeDecay());
    }

    public void StopBulletTime(InputAction.CallbackContext context)
    {
        StopBulletTime();
    }

    public void StopBulletTime()
    {
        Time.timeScale = 1;
        if(currentRoutine != null) StopCoroutine(currentRoutine);
        playerController.turnSpeedMultiplier = 1;
        currentRoutine = StartCoroutine(BulletTimeGrowth());
    }

    IEnumerator BulletTimeDecay()
    {
        while(bulletTime > 0)
        {
            yield return null;
            bulletTime -= Time.deltaTime * (1/Time.timeScale);
            bulletTimeBar.UpdateStatusBar(maxBulletTime, bulletTime);
        }
        bulletTime = 0;

        StopBulletTime();
    }

    IEnumerator BulletTimeGrowth()
    {
        while(bulletTime < maxBulletTime)
        {
            yield return null;
            bulletTime += bulletTimeGrowth * Time.deltaTime * (1 / Time.timeScale);
            bulletTimeBar.UpdateStatusBar(maxBulletTime, bulletTime);
        }
        bulletTime = maxBulletTime;
    }
}
