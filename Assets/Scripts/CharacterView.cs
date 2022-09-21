
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    //для достапа к СпрайтРендерер. Чтобы создать анимированное движение персонажа
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [Header("Settings")]//отделим поля в которых что-то перемещаем от числовых полей

    [SerializeField]//скорость ходьбы/движения
    private float _walkSpeed = 1f;

    [SerializeField]//скорость анимации
    private float _animatonSpeed = 3f;

    [SerializeField]//скрость прыжка
    private float _jumpStartSpeed = 2f;

    [SerializeField]//для понимания стоим или движемся. Свыше этого значения начинается ходьба.
    private float _moveThresh = 0.1f;

    [SerializeField]//для определения в полете мы или стоим на земле
    private float _flyThresh = 0.4f;

    [SerializeField]//определение поверхности земли
    private float _groundLevel = 0.5f;

    [SerializeField]//ускорение
    private float _acceleration = -10f;//примерное значение ускорения свободного падения

    public SpriteRenderer SpriteRenderer => _spriteRenderer;

    
    public float WalkSpeed => _walkSpeed;
    public float AnimatonSpeed => _animatonSpeed;
    public float JumpStartSpeed => _jumpStartSpeed;
    public float MoveThresh => _moveThresh;
    public float FlyThresh => _flyThresh;
    public float GroundLevel => _groundLevel;
    public float Acceleration => _acceleration;
}
