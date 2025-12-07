using Unity.VisualScripting;
using UnityEngine;

public class TargetMoover : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _speed;

    private int _currentWaypoint = 0;

    private void Update()
    {
        if (transform.position == _wayPoints[_currentWaypoint].position)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _wayPoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }
}
