using UnityEngine;

[CreateAssetMenu(fileName = "CollectQuestData", menuName = "Quests/Collect Quest Data")]
public class CollectQuestData : QuestData
{
    [Header("Collect Quest Data")]
    public CollectibleType collectibleType;

    public override void InitializeRuntimeQuest()
    {
        currentProgress = 0;
        isCompleted = false;

        EventManager.Instance.OnCollectiblePickedUp += HandleCollectiblePickedUp;
    }

    public override void CancelRuntimeQuest()
    {
        EventManager.Instance.OnCollectiblePickedUp -= HandleCollectiblePickedUp;
    }

    private void HandleCollectiblePickedUp(CollectibleType type)
    {
        if (isCompleted || type != collectibleType) return;

        currentProgress = Mathf.Min(currentProgress + 1, requiredAmount);
        NotifyProgress();
    }
}