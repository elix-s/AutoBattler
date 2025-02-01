using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory[] _enemyFactories; 
    [SerializeField] private Transform _player;
    [SerializeField] private float _spawnRadius = 5f; 
    [SerializeField] private float _spawnInterval = 1f; 

    private void Start()
    {
        if (_enemyFactories == null || _enemyFactories.Length == 0)
        {
            Debug.LogError("EnemyFactories array is not assigned or empty!");
            return;
        }

        if (_player == null)
        {
            Debug.LogError("Player is not assigned!");
            return;
        }

        InvokeRepeating("SpawnEnemies", 0f, _spawnInterval);
    }

    private void SpawnEnemies()
    {
        foreach (var factory in _enemyFactories)
        {
            if (factory == null)
            {
                Debug.LogError("One of the enemy factories is not assigned!");
                continue;
            }

            Vector2 spawnPosition = (Vector2)_player.position + Random.insideUnitCircle.normalized * _spawnRadius;
            Enemy enemy = factory.CreateEnemy(spawnPosition, _player);

            if (enemy == null)
            {
                Debug.LogError("Failed to create enemy!");
                continue;
            }
        }
    }
}