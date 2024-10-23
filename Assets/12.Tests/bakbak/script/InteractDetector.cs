using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractDetector : MonoBehaviour
{
    [SerializeField] private Transform _detectorPosition;
    [SerializeField] private LayerMask _detectorLayerMask;
    List<Collider> collidersInRange = new List<Collider>();
    Dictionary<Collider, IInteractable> interacts = new Dictionary<Collider, IInteractable>();

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        IEnterInteractionHandler interaction = other.GetComponent<IEnterInteractionHandler>();

        interacts.Add(other, interaction);
        collidersInRange.Add(other);

        if (CheckObjectDistant(collidersInRange) == other)
        {
            (interacts[other] as IEnterInteractionHandler).EnterInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        (interacts[other] as IExitInterationHandler).ExitInteraction();
        
        collidersInRange.Remove(other);
        interacts.Remove(other);

        if (collidersInRange.Count > 0)
        {
            (interacts[CheckObjectDistant(collidersInRange)] as IEnterInteractionHandler).EnterInteraction();
        }
    }

    /// <summary>
    /// 콜라이더중 가장 가까운 콜라이더를 반환하는 함수입니다.
    /// </summary>
    /// <param name="colliders"></param>
    /// <returns></returns>
    private Collider CheckObjectDistant(List<Collider> colliders)
    {
        Collider closestCollider = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            float distance = Vector3.Distance(transform.position, collider.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestCollider = collider;
            }
        }

        return closestCollider;
    }
}
