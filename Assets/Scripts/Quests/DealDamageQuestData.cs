using UnityEngine;

[CreateAssetMenu(fileName = "DealDamageQuestData", menuName = "Quests/Deal Damage Quest Data")]
public class DealDamageQuestData : QuestData
{
    public override void InitializeRuntimeQuest()
    {
        currentProgress = 0;
        isCompleted = false;

        EventManager.Instance.OnDamageDone += HandleDamageDone;
    }

    public override void CancelRuntimeQuest()
    {
        EventManager.Instance.OnDamageDone -= HandleDamageDone;
    }

    private void HandleDamageDone(int damage)
    {
        if (isCompleted) return;

        currentProgress = Mathf.Min(currentProgress + damage, requiredAmount);
        NotifyProgress();
    }
}
