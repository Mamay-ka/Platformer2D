
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Vector3 _vectorA;
    [SerializeField] private Vector3 _vectorB;

    //[SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private float _timeMove = 10;

    private Vector3 _startPosition;//���������� ��� ��������� ������� ������ �������/������
    private float _timer;

    private void Start()
    {
        //���������� ����� ���������
        var distance1 = (_vectorA - _vectorB).magnitude;//1 ������ ����������
        Debug.Log(distance1);

        var distance2 = Vector3.Distance(_vectorA, _vectorB); //2 ������ ����������
        Debug.Log(distance2);

        //����������� ������
        var directionNormalize = (_vectorB - _vectorA).normalized;
        Debug.Log(directionNormalize);

        //��������� ������������ ��������. ����� ���������� �������������� �������� ������������ ���� �����
        var dot = Vector3.Dot(_vectorA, _vectorB);
        Debug.Log(dot);

        //��������� ������������. ������� �������������
        var cross = Vector3.Cross(_vectorA, _vectorB);
        Debug.Log(cross);

        _startPosition = transform.position;//��������� ����� �������� ������ �������/������
        _timer = Time.time;//�����, ������� ������ �� ������ ������
    }

        //�������� ������������. ����������� �������
    private void Update()
    {
        var t = (Time.time - _timer)/_timeMove;
        transform.position =  Vector3.Lerp(_startPosition, _point2.position, t);
    }

}

