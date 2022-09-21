using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHeroWalker 
{
    private const string Horizontal = nameof(Horizontal);//константы для перемещения игрока влево/вправо
    private const string Vertical = nameof(Vertical);

    private float _yVelocity;//скорость для оси Y для прыжка

    private readonly CharacterView _characterView;
    private readonly SpriteAnimator _spriteAnimator;

    
    public MainHeroWalker(CharacterView characterView, SpriteAnimator spriteAnimator)
    {
      _characterView = characterView;
       _spriteAnimator = spriteAnimator;
    }

    
    public void Update()
    {
        var doJump = Input.GetAxis(Vertical) > 0;//надо понять, прыгаем ли мы
        var xAxisInput = Input.GetAxis(Horizontal);//надо понять движемся ли мы 

                            //модуль числа
        var isGoSideWay = Mathf.Abs(xAxisInput) > _characterView.MoveThresh;//надо понять куда именно движемся мы (влево/вправо)

        if(isGoSideWay)
        {
            GoSideWay(xAxisInput);
        }

        if (isGrounded())//нужно понять на земле ли мы
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, isGoSideWay ? Track.walk : Track.idle, true, _characterView.AnimatonSpeed);


            if (doJump && Mathf.Approximately(_yVelocity, 0))//метод сравнение для флотовских значений
            {
                _yVelocity = _characterView.JumpStartSpeed;
            }
            else if (_yVelocity < 0)
            {
                _yVelocity = 0;
                MovementCharacter();//перемещаем персонажа на уровень земли
            }
        }
        else
        {
            LandingCharacter();
        }
    }

    private void LandingCharacter()
    {
        _yVelocity += _characterView.Acceleration * Time.deltaTime;
        
        if(Mathf.Abs(_yVelocity) > _characterView.FlyThresh)
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.jump, true, _characterView.AnimatonSpeed);
        }

        _characterView.transform.position += Vector3.up * (Time.deltaTime * _yVelocity); 
    }

    private void MovementCharacter()
    {
        _characterView.transform.position = _characterView.transform.position.Change(y: _characterView.GroundLevel);
    }

    private bool isGrounded()
    {
        return _characterView.transform.position.y <=_characterView.GroundLevel && _yVelocity <=0;
    }

    private void GoSideWay(float xAxisInput)
    {
        _characterView.transform.position += Vector3.right * (Time.deltaTime * _characterView.WalkSpeed * (xAxisInput < 0 ? -1 : 1 )); //перемещаем персонажа
        _characterView.SpriteRenderer.flipX = xAxisInput < 0;//поворачиваем спрайт нашего персонажа влево/вправо
    }
}
