using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform interactOrigin;
    [SerializeField] float interactRange = 1.5f;
    [SerializeField] LayerMask interactableLayer;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            TryInteract();
        }
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

        if (closestInteractable != null)
        {
            closestInteractable.Interact();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        if (interactOrigin != null)
            Gizmos.DrawWireSphere(interactOrigin.position, interactRange);
    }


}
