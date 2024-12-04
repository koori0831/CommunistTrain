using Unity.Cinemachine;
using UnityEngine;

public class SmalStationCamMoving : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private float angleMax;
    [SerializeField] private float deadzoneWidth = 1f; // Explicit deadzone width
    [SerializeField] private float smoothingSpeed = 5f; // Smoothing speed

    private Vector3 _currentEulerAngles;


    private void LateUpdate()
    {
        LockAtTarget();
    }

    private void LockAtTarget()
    {
        float targetX = followTarget.position.x;

        // Calculate the desired angle based on target position outside the deadzone
        float desiredAngle = 0;
        if (Mathf.Abs(targetX) > deadzoneWidth)
        {
            desiredAngle = Mathf.Clamp((targetX - Mathf.Sign(targetX) * deadzoneWidth) * 0.3f, -angleMax, angleMax); //Adjusted offset calculation
        }


        // Smoothly interpolate towards the desired angle
        _currentEulerAngles = transform.eulerAngles;
        _currentEulerAngles.y = Mathf.LerpAngle(_currentEulerAngles.y, desiredAngle, smoothingSpeed * Time.deltaTime);
        transform.eulerAngles = _currentEulerAngles;
    }
}