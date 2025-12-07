using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 10;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>
        (
            createFunc: CreateEnemy,
            actionOnGet: ActivateEnemy,
            actionOnRelease: DeactivateEnemy,
            actionOnDestroy: DestroyEnemy,
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        );
    }

    public void ReleaseEnemy(Enemy enemy)
    {
        enemy.Release -= ReleaseEnemy;

        _pool.Release(enemy);
    }

    public Enemy GetEnemy()
    {
        return _pool.Get();
    }

    private Enemy CreateEnemy()
    {
        return Instantiate(_enemy);
    }

    private void ActivateEnemy(Enemy enemy)
    {
        enemy.Release += ReleaseEnemy;

        enemy.gameObject.SetActive(true);
    }

    private void DeactivateEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void DestroyEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}
