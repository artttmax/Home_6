using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemiesPool;
    [SerializeField] private GameObject _target;

    private Coroutine _coroutine;
    private EnemySpawner _spawner; 
    private float _spawnInterval = 2f;
    private bool _isWork = true;

    private void OnEnable()
    {
        _spawner = this;

        _coroutine = StartCoroutine(SpawnEnemyAfterDelay(_spawnInterval));
    }

    private IEnumerator SpawnEnemyAfterDelay(float delay)
    {
        while (_isWork)
        {
            yield return new WaitForSeconds(delay);

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemy = _enemiesPool.GetEnemy();
        EnemyMoover moover = enemy.GetComponent<EnemyMoover>();

        enemy.transform.position = _spawner.transform.position;

        moover.GetTarget(_target);
    }

}
