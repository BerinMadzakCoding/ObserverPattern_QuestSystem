using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject skeletonPrefab;
    [SerializeField] private GameObject ghostPrefab;

    const float respawnTime = 20f;

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

    public void Respawn(EnemyType type, Vector3 position)
    {
        StartCoroutine(Spawn(type, position));
    }

    private void SpawnEnemy(EnemyType type, Vector3 position)
    {
        GameObject enemyPrefab = type switch
        {
            EnemyType.Zombie => zombiePrefab,
            EnemyType.Skeleton => skeletonPrefab,
            EnemyType.Ghost => ghostPrefab,
            _ => zombiePrefab
        };

        Instantiate(enemyPrefab, position, Quaternion.identity);
    }
    
    private IEnumerator Spawn(EnemyType type, Vector3 position)
    {
        yield return new WaitForSeconds(respawnTime);
        SpawnEnemy(type, position);
    }
}
