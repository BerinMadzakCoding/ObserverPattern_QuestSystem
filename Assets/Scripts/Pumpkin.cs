using UnityEngine;

public class Pumpkin : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject pumpkinObject;
    [SerializeField] private Collider[] colliders;

    private bool isCollected = false;

    public void Interact()
    {
        if (isCollected) return;
        isCollected = true;

        InteractManager.Instance.SetInteractable("");
        pumpkinObject.SetActive(false);
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }

        EventManager.Instance.HandleCollectiblePickedUp(CollectibleType.Pumpkin);

        Invoke("Respawn", 20f);
    }

    private void Respawn()
    {
        isCollected = false;
        pumpkinObject.SetActive(true);
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        if (isCollected) return;

        if (other.TryGetComponent(out PlayerController playerController))
        {
            InteractManager.Instance.SetInteractable("Press <b><color=red>E</color></b> to pick up the pumpkin.", this);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isCollected) return;

        if (other.TryGetComponent(out PlayerController playerController))
        {
            InteractManager.Instance.SetInteractable("");
        }
    }
}
