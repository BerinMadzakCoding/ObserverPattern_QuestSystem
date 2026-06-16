using UnityEngine;

public class Questgiver : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interact with Questgiver");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            InteractManager.Instance.SetInteractable("Press <b><color=red>E</color></b> to talk to the questgiver.", this);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            InteractManager.Instance.SetInteractable("");
        }
    }
}