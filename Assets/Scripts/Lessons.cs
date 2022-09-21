using System.Collections.Generic;
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

    private ParalaxManager _paralaxManager;

    private SpriteAnimator _spriteAnimator;

    private MainHeroWalker _mainHeroWalker;

    private AimingMuzzle _aimingMuzzle;

    private BulletsEmitter _bulletsEmitter;

    
    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _background.transform);
        //_spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.walk, true, 10);
        _mainHeroWalker = new MainHeroWalker(_characterView, _spriteAnimator);
        _aimingMuzzle = new AimingMuzzle(_cannonView.transform, _characterView.transform);
        _bulletsEmitter = new BulletsEmitter(_bullets, _cannonView.MuzzleTransform);
    }

    
    private void Update()
    {
        
        _paralaxManager.Update();
        _spriteAnimator.Update();

        _mainHeroWalker.Update();
        _aimingMuzzle.Update();
        _bulletsEmitter.Update();
    }

    
    private void FixedUpdate()
    {
        
    }

    
    private void OnDestroy()
    {
        
    }
}
