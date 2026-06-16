using TMPro;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public static InteractManager Instance { get; private set; }

    [SerializeField] TMP_Text interactText;

    private IInteractable interactable;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetInteractable(string text, IInteractable interactable = null)
    {
        this.interactable = interactable;
        interactText.text = text;
    }

    public void TriggerInteract()
    {
        interactable?.Interact();
    }
}
