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
        var distance = Vector2.Distance(_target.position, fromPosition);//определяем расстояние от текущего положения до точки ВэйПойнта
        if (distance <= _config.MinDistanceToTarget)
            _target = GetNextWaypoint();
        var direction =((Vector2) _target.position - fromPosition).normalized;//(Vector2) _target.position - таким образом из Вектора3 сделали Вектор2
        return direction * _config.Speed;//вычислили вектор скорости
    }
    private Transform GetNextWaypoint()
    {
        _correntPointIndex = (_correntPointIndex + 1) % _config.Waypoints.Length;//остаток от деления для получения нулевого индекса
        return _config.Waypoints[_correntPointIndex];
    }
}
