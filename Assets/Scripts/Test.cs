
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Vector3 _vectorA;
    [SerializeField] private Vector3 _vectorB;

    //[SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private float _timeMove = 10;

    private Vector3 _startPosition;//переменна€ дл€ начальной позиции нашего объекта/кубика
    private float _timer;

    private void Start()
    {
        //рассто€ние между векторами
        var distance1 = (_vectorA - _vectorB).magnitude;//1 способ вычислени€
        Debug.Log(distance1);

        var distance2 = Vector3.Distance(_vectorA, _vectorB); //2 способ вычислени€
        Debug.Log(distance2);

        //нормализуем вектор
        var directionNormalize = (_vectorB - _vectorA).normalized;
        Debug.Log(directionNormalize);

        //скал€рное произведение векторов. „тобы определить направленность векторов относительно друг друга
        var dot = Vector3.Dot(_vectorA, _vectorB);
        Debug.Log(dot);

        //векторное произведение. Ќаходим перпендикул€р
        var cross = Vector3.Cross(_vectorA, _vectorB);
        Debug.Log(cross);

        _startPosition = transform.position;//начальна€ точка движени€ нашего объекта/кубика
        _timer = Time.time;//врем€, которое прошло от начала старта
    }

        //линейна€ интерпол€ци€. перемещение объекта
    private void Update()
    {
        var t = (Time.time - _timer)/_timeMove;
        transform.position =  Vector3.Lerp(_startPosition, _point2.position, t);
    }

}

