using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFlip : MonoBehaviour
{
    private NavMeshAgent _agent;
    private float facingDirection = -1;
    [SerializeField]
    private bool _isZDirection=false;

    private void Awake()
    {
        _agent = GetComponentInParent<NavMeshAgent>();
    }

    private void Update()
    {
        print(facingDirection + _agent.velocity.x);
        if(Mathf.Abs(facingDirection + _agent.velocity.x) < 0.5f&&!_isZDirection)
        {
            Flip();
        }
        else if(Mathf.Abs(facingDirection + _agent.velocity.z) < 0.5f)
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
