using UnityEngine;

public class SmalStationCamMoving : MonoBehaviour
{
    [SerializeField] private Transform _pcTrm;
    [SerializeField] private float _angleMax;

    private void LateUpdate()
    {
        Vector3 currentEulerAngles = transform.eulerAngles;
        currentEulerAngles.y = Mathf.Clamp(_pcTrm.position.x *0.3f, -_angleMax, _angleMax);
        transform.eulerAngles = currentEulerAngles;
    }
}