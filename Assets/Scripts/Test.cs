
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Vector3 _vectorA;
    [SerializeField] private Vector3 _vectorB;

    //[SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private float _timeMove = 10;

    private Vector3 _startPosition;//переменная для начальной позиции нашего объекта/кубика
    private float _timer;

    private void Start()
    {
        //расстояние между векторами
        var distance1 = (_vectorA - _vectorB).magnitude;//1 способ вычисления
        Debug.Log(distance1);

        var distance2 = Vector3.Distance(_vectorA, _vectorB); //2 способ вычисления
        Debug.Log(distance2);

        //нормализуем вектор
        var directionNormalize = (_vectorB - _vectorA).normalized;
        Debug.Log(directionNormalize);

        //скалярное произведение векторов. Чтобы определить направленность векторов относительно друг друга
        var dot = Vector3.Dot(_vectorA, _vectorB);
        Debug.Log(dot);

        //векторное произведение. Находим перпендикуляр
        var cross = Vector3.Cross(_vectorA, _vectorB);
        Debug.Log(cross);

        _startPosition = transform.position;//начальная точка движения нашего объекта/кубика
        _timer = Time.time;//время, которое прошло от начала старта
    }

        //линейная интерполяция. перемещение объекта
    private void Update()
    {
        var t = (Time.time - _timer)/_timeMove;
        transform.position =  Vector3.Lerp(_startPosition, _point2.position, t);

        //Rigidbody2D _rigidbody2D = new Rigidbody2D();
        // _rigidbody2D.AddForce(Vector3.right)//направим силу вправо
        //_rigidbody2D.AddForceAtPosition(Vector3.right, transform.localPosition + Vector3.right);//прикладываем силу к какой-нибудь точке тела
        //_rigidbody2D.AddTorque(5);//вращательный момент относительно оси Z
    }

}

