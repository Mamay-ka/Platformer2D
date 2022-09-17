
using UnityEngine;

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

    private ParalaxManager _paralaxManager;//создадим объект класса ParalaxManager 

    private SpriteAnimator _spriteAnimator;

    //далее инициализируем все контроллеры в методе Старт
    private void Start()
    {
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.walk, true, 10);

        _paralaxManager = new ParalaxManager(_camera, _background.transform);//инициализируем данное поле. Создаем конструктор и перемещаем на вход камеру
    }

    //в методе апдэйт будет крутиться логика
    private void Update()
    {
        _spriteAnimator.Update();

        _paralaxManager.Update();//теперь конструктор в Апдейте нужно обновлять каждый раз.(взяли Update из класса ParalaxManager )
    }

    //для движения персонажа при помощи физики понадобится фикседАпдэйт
    private void FixedUpdate()
    {
        
    }

    //чтобы чистить наши контроллеры
    private void OnDestroy()
    {
        
    }
}
