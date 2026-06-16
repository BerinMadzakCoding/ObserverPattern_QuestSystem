using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private EnemyController enemyController;

    void OnEnable()
    {
        enemyController.OnHealthChanged += HandleHealthChanged;
        enemyController.OnDie += Despawn;
    }

    void OnDisable()
    {
        enemyController.OnHealthChanged -= HandleHealthChanged;
        enemyController.OnDie -= Despawn;
    }

    private void HandleHealthChanged(float currentHealth, float maxHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    private void Despawn()
    {
        Destroy(gameObject, 0.3f);
    }
}
