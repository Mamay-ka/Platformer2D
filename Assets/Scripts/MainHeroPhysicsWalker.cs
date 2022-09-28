
using UnityEngine;

public class MainHeroPhysicsWalker 
{
    private const string Horizontal = nameof(Horizontal);//константы для перемещения игрока влево/вправо
    private const string Vertical = nameof(Vertical);

    private readonly CharacterView _characterView;
    private readonly SpriteAnimator _spriteAnimator;
    private readonly ContactsPoller _contactsPoller;

    public MainHeroPhysicsWalker(CharacterView characterView, SpriteAnimator spriteAnimator)
    {
       _characterView = characterView;
        _spriteAnimator = spriteAnimator;

        _contactsPoller = new ContactsPoller(_characterView.Collider2D);
    }

    public void FixedUpdate()
    {
        var doJump = Input.GetAxis(Vertical) > 0;//надо понять, прыгаем ли мы
        var xAxisInput = Input.GetAxis(Horizontal);//надо понять движемся ли мы 

        _contactsPoller.Update();

        var isGoSideWay = Mathf.Abs(xAxisInput) > _characterView.MoveThresh;

        if (isGoSideWay)
            _characterView.SpriteRenderer.flipX = xAxisInput < 0;//поворачиваем спрайт нашего персонажа влево/вправо

        var newVelocityX = 0f;

        if(isGoSideWay &&
            (xAxisInput > 0 || !_contactsPoller.HasLeftContacts) &&
            (xAxisInput < 0 || !_contactsPoller.HasRightContacts))
        {
            newVelocityX = Time.fixedDeltaTime * _characterView.WalkSpeed * (xAxisInput < 0 ? -1 : 1);
        }
        _characterView.Rigidbody.velocity = _characterView.Rigidbody.velocity.Change(x: newVelocityX);

        if(_contactsPoller.IsGrounded && doJump
            && _characterView.Rigidbody.velocity.y <= _characterView.FlyThresh)
        {
            _characterView.Rigidbody.AddForce(Vector2.up * _characterView.JumpStartSpeed);
        }

        if (_contactsPoller.IsGrounded)
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, isGoSideWay ? Track.walk : Track.idle,
                true, _characterView.AnimatonSpeed);
        }
        else if(Mathf.Abs(_characterView.Rigidbody.velocity.y) > _characterView.FlyThresh)
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.jump,
                true, _characterView.AnimatonSpeed);
        }
                
    }
}
