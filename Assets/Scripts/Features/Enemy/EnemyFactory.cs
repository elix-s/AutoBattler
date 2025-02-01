using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab; 

    public Enemy CreateEnemy(Vector2 position, Transform target)
    {
        if (_enemyPrefab == null)
        {
            Debug.LogError("Enemy prefab is not assigned!");
            return null;
        }

        GameObject enemy = Instantiate(_enemyPrefab, position, Quaternion.identity);
        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        if (enemyComponent == null)
        {
            Debug.LogError("Enemy component is missing on the prefab!");
            return null;
        }
        
        enemyComponent.SetTarget(target);
        return enemyComponent;
    }
}
