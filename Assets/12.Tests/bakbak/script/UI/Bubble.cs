using UnityEngine;

public class Bubble : MonoBehaviour, Ipoolable
{
    public string PoolName => gameObject.name;

    public GameObject ObjectPrefab => gameObject;

    public void ResetItem()
    {
        transform.localPosition = Vector3.zero;
    }
}
