using UnityEngine;

[CreateAssetMenu(fileName = "KillQuestData", menuName = "Quests/Kill Quest Data")]
public class KillQuestData : QuestData
{
    [Header("Kill Quest Data")]
    public EnemyType enemyType;

    public override void InitializeRuntimeQuest()
    {
        currentProgress = 0;
        isCompleted = false;

        EventManager.Instance.OnEnemyKilled += HandleEnemyKilled;
    }

    public override void CancelRuntimeQuest()
    {
        EventManager.Instance.OnEnemyKilled -= HandleEnemyKilled;
    }

    private void HandleEnemyKilled(EnemyType type)
    {
        if (isCompleted || (type != enemyType && type != EnemyType.All)) return;

        currentProgress = Mathf.Min(currentProgress + 1, requiredAmount);
        NotifyProgress();
    }
}