using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractDetector : MonoBehaviour
{
    [SerializeField] private Transform _detectorPosition;
    [SerializeField] private LayerMask _detectorLayerMask;
    List<Collider> collidersInRange = new List<Collider>();
    Dictionary<Collider, IInteraction> interacts = new Dictionary<Collider, IInteraction>();

    private Collider currentClosestCollider;
    [SerializeField]
    private InputReader _inputReader;
    private void Awake()
    {
        _inputReader.OnInteraction += InteractionTry;
    }
    private void OnTriggerEnter(Collider other)
    {

        IEnterInteractableHandler interaction = other.GetComponent<IEnterInteractableHandler>();

        if(!interacts.ContainsKey(other))
        {
            interacts.Add(other, interaction);
            collidersInRange.Add(other);
        }
        else
        {
            currentClosestCollider = null;
            collidersInRange.Clear();
        }

        InteractEnable();
    }

    private void OnDestroy()
    {
        if ((_inputReader != null))
        {
            _inputReader.OnInteraction -= InteractionTry;
        }
    }

    private void InteractionTry()
    {
        if (currentClosestCollider == null) return;
        interacts[currentClosestCollider].Interact();
    }

    private void OnTriggerExit(Collider other)
    {
        InteractEnable();
        collidersInRange.Remove(other);
        if(interacts.Count <= 1&&currentClosestCollider!=null)
        {
            (interacts[currentClosestCollider] as IExitInteratableHandler).ExitInteraction();
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
        if (interacts.Count<=0)
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
                    IExitInteratableHandler exitHandler = interacts[currentClosestCollider] as IExitInteratableHandler;

                    exitHandler?.ExitInteraction();
                }
            }

            if (closestCollider != null)
            {
                currentClosestCollider = closestCollider;
                IEnterInteractableHandler enterHandler = interacts[currentClosestCollider] as IEnterInteractableHandler;

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
