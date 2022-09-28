using System.Collections.Generic;
using UnityEngine;
using System;

public class Lessons : MonoBehaviour
{
    //хотим сделать парралакс. Создадим два поля
    [SerializeField]
    private Camera _camera; //положение камеры

    [SerializeField]
    private SpriteRenderer _background;//здесь будет бэкграунд/фон

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
                
    private ParalaxManager _paralaxManager;//создадим объект класса ParalaxManager 

    private SpriteAnimator _spriteAnimator;

    //private MainHeroWalker _mainHeroWalker;

    private MainHeroPhysicsWalker _mainPhysicsHeroWalker;

    private AimingMuzzle _aimingMuzzle;

    private BulletsEmitter _bulletsEmitter;

    //далее инициализируем все контроллеры в методе Старт
    private void Start()
    {
        _levelCompleteManager = new LevelCompleteManager(_levelObjectViews);//!
        _coinsManager = new CoinsManager(_coinViews);
        _paralaxManager = new ParalaxManager(_camera, _background.transform);//инициализируем данное поле. Создаем конструктор и перемещаем на вход камеру
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        //_spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.walk, true, 10);
        //_mainHeroWalker = new MainHeroWalker(_characterView, _spriteAnimator);//создали объект
        _mainPhysicsHeroWalker = new MainHeroPhysicsWalker(_characterView, _spriteAnimator);
        _aimingMuzzle = new AimingMuzzle(_cannonView.transform, _characterView.transform);
        _bulletsEmitter = new BulletsEmitter(_bullets, _cannonView.MuzzleTransform);

    }

    //в методе апдэйт будет крутиться логика
    private void Update()
    {
        
        _paralaxManager.Update();//теперь конструктор в Апдейте нужно обновлять каждый раз.(взяли Update из класса ParalaxManager )
        _spriteAnimator.Update();

        //_mainHeroWalker.Update();//запустили Апдэйт из данного кoнтроллера
        _aimingMuzzle.Update();
        _bulletsEmitter.Update();
    }

    //для движения персонажа при помощи физики понадобится фикседАпдэйт
    private void FixedUpdate()
    {
        _mainPhysicsHeroWalker.FixedUpdate();
    }

    //чтобы чистить наши контроллеры
    private void OnDestroy()
    {
        _coinsManager.Dispose();
        _levelCompleteManager.Dispose();//!
    }
}

