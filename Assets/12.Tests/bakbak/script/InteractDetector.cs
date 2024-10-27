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

    private Collider currentClosestCollider;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        IEnterInteractionHandler interaction = other.GetComponent<IEnterInteractionHandler>();

        interacts.Add(other, interaction);
        collidersInRange.Add(other);

        InteractEnable();
    }

    private void OnTriggerExit(Collider other)
    {
        InteractEnable();
        collidersInRange.Remove(other);
        if(interacts.Count == 1)
        {
            (interacts[currentClosestCollider] as IExitInterationHandler).ExitInteraction();
            currentClosestCollider = null;
        }
        interacts.Remove(other);
    }
    private void Update()
    {
        InteractEnable();
    }

    private void InteractEnable()
    {
        if (interacts.IsUnityNull())
        {
            currentClosestCollider = null;
            return;
        }

        Collider closestCollider = CheckObjectDistant(collidersInRange);
        if (currentClosestCollider != closestCollider)
        {
            if (currentClosestCollider != null)
            {
                if (interacts.Count > 0)
                {
                    IExitInterationHandler exitHandler = interacts[currentClosestCollider] as IExitInterationHandler;

                    exitHandler?.ExitInteraction();
                }
            }

            if (closestCollider != null)
            {
                currentClosestCollider = closestCollider;
                IEnterInteractionHandler enterHandler = interacts[currentClosestCollider] as IEnterInteractionHandler;

                enterHandler?.EnterInteraction();
            }
        }
    }

    /// <summary>
    /// 콜라이더중 가장 가까운 콜라이더를 반환하는 함수.
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
