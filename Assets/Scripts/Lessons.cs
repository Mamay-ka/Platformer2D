
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

    private MainHeroWalker _mainHeroWalker;

    //����� �������������� ��� ����������� � ������ �����
    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _background.transform);//�������������� ������ ����. ������� ����������� � ���������� �� ���� ������
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        //_spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.walk, true, 10);
        _mainHeroWalker = new MainHeroWalker(_characterView, _spriteAnimator);//������� ������
    }

    //� ������ ������ ����� ��������� ������
    private void Update()
    {
        
        _paralaxManager.Update();//������ ����������� � ������� ����� ��������� ������ ���.(����� Update �� ������ ParalaxManager )
        _spriteAnimator.Update();

        _mainHeroWalker.Update();//��������� ������ �� ������� �o���������
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
