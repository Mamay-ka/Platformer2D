
using UnityEngine;

public class Lessons : MonoBehaviour
{
    //����� ������� ���������. �������� ��� ����
    [SerializeField]
    private Camera _camera; //��������� ������

    [SerializeField]
    private SpriteRenderer _background;//����� ����� ���������/���

    [SerializeField]
    private CharacterView _characterView;

    [SerializeField]
    private SpriteAnimationsConfig _spriteAnimationConfig;

    private ParalaxManager _paralaxManager;//�������� ������ ������ ParalaxManager 

    private SpriteAnimator _spriteAnimator;

    //����� �������������� ��� ����������� � ������ �����
    private void Start()
    {
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.walk, true, 10);

        _paralaxManager = new ParalaxManager(_camera, _background.transform);//�������������� ������ ����. ������� ����������� � ���������� �� ���� ������
    }

    //� ������ ������ ����� ��������� ������
    private void Update()
    {
        _spriteAnimator.Update();

        _paralaxManager.Update();//������ ����������� � ������� ����� ��������� ������ ���.(����� Update �� ������ ParalaxManager )
    }

    //��� �������� ��������� ��� ������ ������ ����������� ������������
    private void FixedUpdate()
    {
        
    }

    //����� ������� ���� �����������
    private void OnDestroy()
    {
        
    }
}
