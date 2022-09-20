
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    //дл€ достапа к —прайт–ендерер. „тобы создать анимированное движение персонажа
    [SerializeField]
    private SpriteRenderer _spriteRenderer;//поле дл€ —прайт–ендерера игрока

    [Header("Settings")]//отделим пол€ в которых что-то перемещаем от числовых полей

    [SerializeField]//скорость ходьбы/движени€
    private float _walkSpeed = 1f;

    [SerializeField]//скорость анимации
    private float _animatonSpeed = 3f;

    [SerializeField]//скрость прыжка
    private float _jumpStartSpeed = 2f;

    [SerializeField]//дл€ понимани€ стоим или движемс€. —выше этого значени€ начинаетс€ ходьба.
    private float _moveThresh = 0.1f;

    [SerializeField]//дл€ определени€ в полете мы или стоим на земле
    private float _flyThresh = 0.4f;

    [SerializeField]//определение поверхности земли
    private float _groundLevel = 0.5f;

    [SerializeField]//ускорение
    private float _acceleration = -10f;//примерное значение ускорени€ свободного падени€

    public SpriteRenderer SpriteRenderer => _spriteRenderer;//свойство

    //добавим свойства сериализованных полей
    public float WalkSpeed => _walkSpeed;
    public float AnimatonSpeed => _animatonSpeed;
    public float JumpStartSpeed => _jumpStartSpeed;
    public float MoveThresh => _moveThresh;
    public float FlyThresh => _flyThresh;
    public float GroundLevel => _groundLevel;
    public float Acceleration => _acceleration;
}
