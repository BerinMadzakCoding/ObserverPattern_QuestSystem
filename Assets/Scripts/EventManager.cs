using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public event Action<CollectibleType> OnCollectiblePickedUp; 
    public event Action<EnemyType> OnEnemyKilled;
    public event Action<int> OnDamageDone;
    public event Action<QuestData> OnQuestAdded;
    public event Action<QuestData> OnQuestCompleted;
    public event Action<string, int> OnQuestProgressUpdated;

    public static EventManager Instance;

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

    public void HandleCollectiblePickedUp(CollectibleType collectibleType)
    {
        OnCollectiblePickedUp?.Invoke(collectibleType);
    }

    public void HandleEnemyKilled(EnemyType type)
    {
        OnEnemyKilled?.Invoke(type);
    }

    public void HandleDamageDone(int damage)
    {
        OnDamageDone?.Invoke(damage);
    }

    public void HandleQuestAdded(QuestData questInstance)
    {
        OnQuestAdded?.Invoke(questInstance);
    }

    public void HandleQuestCompleted(QuestData questInstance)
    {
        OnQuestCompleted?.Invoke(questInstance);
    }

    public void HandleQuestProgressUpdated(QuestData questInstance, int progress)
    {
        OnQuestProgressUpdated?.Invoke(questInstance.QuestID, progress);
    }
}