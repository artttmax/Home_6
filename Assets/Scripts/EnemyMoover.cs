using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMoover : MonoBehaviour
{
    private float _speed = 1.0f;
    private GameObject _target;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    public void GetTarget(GameObject target)
    {
        _target = target;
    }
}
