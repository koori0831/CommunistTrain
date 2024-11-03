using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFlip : MonoBehaviour
{
    private NavMeshAgent _agent;
    private float facingDirection = -1;

    private void Awake()
    {
        _agent = GetComponentInParent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Mathf.Abs(facingDirection + _agent.velocity.x) < 0.5f)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z);
    }
}
