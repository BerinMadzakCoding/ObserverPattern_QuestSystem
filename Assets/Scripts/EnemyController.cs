using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public event System.Action<float, float> OnHealthChanged;
    public event System.Action OnDie;

    private static readonly int DieHash = Animator.StringToHash("Die");

    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject lootPrefab;

    [Header("Stats")]
    [SerializeField] private EnemyType type;
    [SerializeField] private int health = 100;

    private int currentHealth;

    private void Start()
    {
        currentHealth = health;
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        OnHealthChanged?.Invoke(currentHealth, health);
        if (currentHealth <= 0)
        {
            Die();
            SpawnLoot();
        }
    }

    private void Die()
    {
        animator.SetTrigger(DieHash);
        col.enabled = false;
        Invoke("Despawn", 2f);
        EnemySpawner.Instance.Respawn(type, transform.position);
        OnDie?.Invoke();
    }

    private void SpawnLoot()
    {
        Coin loot = Instantiate(lootPrefab, transform.position, Quaternion.identity).GetComponent<Coin>();
        loot.Throw();
    }

    private void Despawn()
    {
        Destroy(gameObject);
    }
}
