using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private TMP_Text questName;
    [SerializeField] private TMP_Text questProgress;
    [SerializeField] private Image background;

    private QuestData data;

    public void SetData(QuestData data)
    {
        this.data = data;

        questName.text = data.questName;
        questProgress.text = $"{data.currentProgress}/{data.requiredAmount}";
    }

    public string GetQuestID => data != null ? data.QuestID : null;

    void OnEnable()
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
        if (data.QuestID == this.data.QuestID)
        {
            Destroy(gameObject, 2f);
        }
    }

    private void HandleQuestProgressUpdated(string questID, int value)
    {
        if(questID == data.QuestID)
        {
            questProgress.text = $"{value}/{data.requiredAmount}";

            if(value >= data.requiredAmount)
            {
                background.color = Color.green;
            } 
        }
    }
}
