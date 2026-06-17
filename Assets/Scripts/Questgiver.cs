using UnityEngine;

public class Questgiver : MonoBehaviour, IInteractable
{
    [SerializeField] private QuestData[] quests;

    public void Interact()
    {
        QuestData quest = quests[Random.Range(0, quests.Length)];
        QuestManager.Instance.AddQuest(quest);
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