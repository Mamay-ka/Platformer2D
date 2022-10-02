using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Lessons : MonoBehaviour
{
    
    [SerializeField]
    private Camera _camera; 

    [SerializeField]
    private SpriteRenderer _background;

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

    [SerializeField]
    private AIConfig _config;

    [SerializeField]
    private EnemyView _enemyView;

    [Header("Protector AI")]
    [SerializeField] private AIDestinationSetter _protectorAIDestinationSetter;
    [SerializeField] private AIPatrolPath _protectorAIPatrolPath;
    [SerializeField] private LevelObjectTrigger _protectedZoneTrigger;
    [SerializeField] private Transform[] _protectorWaypoints;

    private LevelCompleteManager _levelCompleteManager;//!

    private CoinsManager _coinsManager;
                
    private ParalaxManager _paralaxManager;

    private SpriteAnimator _spriteAnimator;

    //private MainHeroWalker _mainHeroWalker;

    private MainHeroPhysicsWalker _mainPhysicsHeroWalker;

    private AimingMuzzle _aimingMuzzle;

    private BulletsEmitter _bulletsEmitter;

    private SimplePatrolAI _simplePatrolAI;

    private ProtectorAI _protectorAI;
    private ProtectedZone _protectedZone;


    private void Start()
    {
        _levelCompleteManager = new LevelCompleteManager(_levelObjectViews);//!
        _coinsManager = new CoinsManager(_coinViews);
        _paralaxManager = new ParalaxManager(_camera, _background.transform);
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        //_spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.walk, true, 10);
        //_mainHeroWalker = new MainHeroWalker(_characterView, _spriteAnimator);//создали объект
        _mainPhysicsHeroWalker = new MainHeroPhysicsWalker(_characterView, _spriteAnimator);
        _aimingMuzzle = new AimingMuzzle(_cannonView.transform, _characterView.transform);
        _bulletsEmitter = new BulletsEmitter(_bullets, _cannonView.MuzzleTransform);
        //_simplePatrolAI = new SimplePatrolAI(_enemyView, new SimplePatrolAIModel(_config));

        _protectorAI = new ProtectorAI(_characterView, new PatrolAIModel(_protectorWaypoints), _protectorAIDestinationSetter, _protectorAIPatrolPath);
        _protectorAI.Init();

        _protectedZone = new ProtectedZone(_protectedZoneTrigger, new List<IProtector> { _protectorAI });
        _protectedZone.Init();
    }

    
    private void Update()
    {
        
        _paralaxManager.Update();
        _spriteAnimator.Update();

        //_mainHeroWalker.Update();
        _aimingMuzzle.Update();
        _bulletsEmitter.Update();
    }

    
    private void FixedUpdate()
    {
        _mainPhysicsHeroWalker.FixedUpdate();
        //_simplePatrolAI.FixedUpdate();
    }

    //чтобы чистить наши контроллеры
    private void OnDestroy()
    {
        _coinsManager.Dispose();
        //_levelCompleteManager.Dispose();//!

        _protectorAI.Deinit();
        _protectedZone.Deinit();
    }
}

