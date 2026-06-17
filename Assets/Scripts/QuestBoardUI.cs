using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestBoardUI : MonoBehaviour
{
    [SerializeField] private QuestUI questUIPrefab;
    [SerializeField] private Transform questParent;

    private List<QuestUI> quests = new List<QuestUI>();

    void OnEnable()
    {
        EventManager.Instance.OnQuestAdded += HandleQuestAdded;
        EventManager.Instance.OnQuestCompleted += HandleQuestCompleted;
    }

    void OnDisable()
    {
        EventManager.Instance.OnQuestAdded -= HandleQuestAdded;
        EventManager.Instance.OnQuestCompleted -= HandleQuestCompleted;
    }

    private void HandleQuestCompleted(QuestData data)
    {
        quests.RemoveAll(q => q.GetQuestID == data.QuestID);
    }

    private void HandleQuestAdded(QuestData data)
    {
        QuestUI ui = Instantiate(questUIPrefab, questParent);
        ui.SetData(data);
        quests.Add(ui);
    }
}
