using UnityEngine;

public class TerrainMove : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 1f;
    private void FixedUpdate()
    {
        if (transform.position.z >= 1000)
            transform.position = new Vector3(0, 0, -1000);
        transform.position += new Vector3(0, 0, _moveSpeed);
    }
}
