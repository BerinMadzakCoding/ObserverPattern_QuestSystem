using UnityEngine;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [SerializeField] private int maxQuests = 5;

    private List<QuestData> quests = new List<QuestData>();

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

    public void AddQuest(QuestData quest)
    {
        if (quest == null || quests.Count >= maxQuests) return;
        
        if (HasActiveQuest(quest.QuestID)) return;
        
        QuestData runningInstance = Instantiate(quest);
        runningInstance.InitializeRuntimeQuest();

        quests.Add(runningInstance);

        EventManager.Instance.HandleQuestAdded(runningInstance);
    }

    private void HandleQuestCompletion(QuestData questInstance)
    {
        quests.Remove(questInstance);
        Destroy(questInstance);
    }

    public bool HasActiveQuest(string id)
    {
        return quests.Exists(q => q.QuestID == id);
    }

    private void OnEnable()
    {
        EventManager.Instance.OnQuestCompleted += HandleQuestCompletion;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnQuestCompleted -= HandleQuestCompletion;
    }
}