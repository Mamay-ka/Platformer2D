using System.Collections.Generic;
using UnityEngine;
using System;

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

    [SerializeField]
    private CannonView _cannonView;

    [SerializeField]
    private List<BulletView> _bullets;

    [SerializeField]
    private List<CoinView> _coinViews;

    [SerializeField]
    private List<LevelObjectView> _levelObjectViews;//!

    private LevelCompleteManager _levelCompleteManager;//!

    private CoinsManager _coinsManager;
                
    private ParalaxManager _paralaxManager;//�������� ������ ������ ParalaxManager 

    private SpriteAnimator _spriteAnimator;

    //private MainHeroWalker _mainHeroWalker;

    private MainHeroPhysicsWalker _mainPhysicsHeroWalker;

    private AimingMuzzle _aimingMuzzle;

    private BulletsEmitter _bulletsEmitter;

    //����� �������������� ��� ����������� � ������ �����
    private void Start()
    {
        _levelCompleteManager = new LevelCompleteManager(_levelObjectViews);//!
        _coinsManager = new CoinsManager(_coinViews);
        _paralaxManager = new ParalaxManager(_camera, _background.transform);//�������������� ������ ����. ������� ����������� � ���������� �� ���� ������
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        //_spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.walk, true, 10);
        //_mainHeroWalker = new MainHeroWalker(_characterView, _spriteAnimator);//������� ������
        _mainPhysicsHeroWalker = new MainHeroPhysicsWalker(_characterView, _spriteAnimator);
        _aimingMuzzle = new AimingMuzzle(_cannonView.transform, _characterView.transform);
        _bulletsEmitter = new BulletsEmitter(_bullets, _cannonView.MuzzleTransform);

    }

    //� ������ ������ ����� ��������� ������
    private void Update()
    {
        
        _paralaxManager.Update();//������ ����������� � ������� ����� ��������� ������ ���.(����� Update �� ������ ParalaxManager )
        _spriteAnimator.Update();

        //_mainHeroWalker.Update();//��������� ������ �� ������� �o���������
        _aimingMuzzle.Update();
        _bulletsEmitter.Update();
    }

    //��� �������� ��������� ��� ������ ������ ����������� ������������
    private void FixedUpdate()
    {
        _mainPhysicsHeroWalker.FixedUpdate();
    }

    //����� ������� ���� �����������
    private void OnDestroy()
    {
        _coinsManager.Dispose();
        _levelCompleteManager.Dispose();//!
    }
}

