using UnityEngine;
using System;

public abstract class QuestData : ScriptableObject 
{
    [Header("Quest Info")]
    public string questName;

    [Header("Runtime Tracking")]
    public int currentProgress;
    public int requiredAmount;
    public bool isCompleted;

    private string questID;
    public string QuestID => questID ?? (questID = Guid.NewGuid().ToString());

    public abstract void InitializeRuntimeQuest();
    public abstract void CancelRuntimeQuest();

    protected void NotifyProgress()
    {
        EventManager.Instance.HandleQuestProgressUpdated(this, currentProgress);

        if(currentProgress >= requiredAmount && !isCompleted)
        {
            isCompleted = true;
            CancelRuntimeQuest();
            EventManager.Instance.HandleQuestCompleted(this);
        }
    }
}

