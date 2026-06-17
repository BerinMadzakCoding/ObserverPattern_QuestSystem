using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private TMP_Text questName;
    [SerializeField] private TMP_Text questProgress;
    [SerializeField] private Image background;

    private QuestData data;
    private string assignedQuestID;

    public string QuestID => data != null ? assignedQuestID : null;

    public void SetData(QuestData data)
    {
        this.data = data;
        assignedQuestID = data.QuestID;

        questName.text = data.questName;
        questProgress.text = $"{data.currentProgress}/{data.requiredAmount}";
    }

    void Start()
    {
        EventManager.Instance.OnQuestProgressUpdated += HandleQuestProgressUpdated;
        EventManager.Instance.OnQuestCompleted += HandleQuestCompleted;
    }

    void OnDisable()
    {
        EventManager.Instance.OnQuestProgressUpdated -= HandleQuestProgressUpdated;
        EventManager.Instance.OnQuestCompleted -= HandleQuestCompleted;
    }

    private void HandleQuestCompleted(QuestData data)
    {
        if (data.QuestID == assignedQuestID)
        {
            Destroy(gameObject, 2f);
        }
    }

    private void HandleQuestProgressUpdated(string questID, int value)
    {
        if(questID == assignedQuestID)
        {
            questProgress.text = $"{value}/{data.requiredAmount}";

            if(value >= data.requiredAmount)
            {
                background.color = Color.green;
            } 
        }
    }
}
