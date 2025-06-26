using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform interactOrigin;
    [SerializeField] float interactRange = 1.5f;
    [SerializeField] LayerMask interactableLayer;

    [SerializeField] Transform holdpoint;
    [SerializeField] float throwForce = 5f;
    [SerializeField] IPickupable heldObject;

    public void OnInteract()
    {
        TryInteract();
    }

    void TryInteract()
    {
        Collider[] colliders = Physics.OverlapSphere(interactOrigin.position, interactRange, interactableLayer);

        float closestDistance = Mathf.Infinity;
        IInteractable closestInteractable = null;

        foreach (Collider collider in colliders)
        {
            IInteractable interactable = collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                float distance = Vector3.Distance(interactOrigin.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestInteractable = interactable;
                }
            }
        }

        if (heldObject != null)
        {
            Vector3 throwDir = interactOrigin.forward;
            heldObject.OnThrow(throwDir * throwForce);
            heldObject = null;
        }
        else if (closestInteractable != null)
        {
            closestInteractable.Interact();

            IPickupable pickupable = closestInteractable as IPickupable;
            if (pickupable != null)
            {
                pickupable.OnPickup(holdpoint);
                heldObject = pickupable;
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        if (interactOrigin != null)
            Gizmos.DrawWireSphere(interactOrigin.position, interactRange);
    }


}
