using UnityEngine;

public class SimplePatrolAIModel 
{
    private readonly AIConfig _config;
    private Transform _target;
    private int _correntPointIndex;

    public SimplePatrolAIModel(AIConfig config)
    {
        _config = config;
        _target = GetNextWaypoint();
    }

    public Vector2 CalculateVelocity(Vector2 fromPosition)
    {
        var distance = Vector2.Distance(_target.position, fromPosition);//���������� ���������� �� �������� ��������� �� ����� ���������
        if (distance <= _config.MinDistanceToTarget)
            _target = GetNextWaypoint();
        var direction =((Vector2) _target.position - fromPosition).normalized;//(Vector2) _target.position - ����� ������� �� �������3 ������� ������2
        return direction * _config.Speed;//��������� ������ ��������
    }
    private Transform GetNextWaypoint()
    {
        _correntPointIndex = (_correntPointIndex + 1) % _config.Waypoints.Length;//������� �� ������� ��� ��������� �������� �������
        return _config.Waypoints[_correntPointIndex];
    }
}
