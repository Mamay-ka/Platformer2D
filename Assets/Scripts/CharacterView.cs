
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    //дл€ достапа к —прайт–ендерер. „тобы создать анимированное движение персонажа
    [SerializeField]
    private SpriteRenderer _spriteRenderer;//поле дл€ —прайт–ендерера игрока

    public SpriteRenderer SpriteRenderer => _spriteRenderer;//свойство
}
