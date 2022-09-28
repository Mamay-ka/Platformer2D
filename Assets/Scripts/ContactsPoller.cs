
using UnityEngine;

public class ContactsPoller //класс для проверки контакта коллайдера нашего персонажа с другими поверхностями
{
    private const float CollisionThresh = 0.1f;//пороговое значение нормали к полу.Для определения, с какой поверхностью мы соприкасаемся

    private ContactPoint2D[] _contacts = new ContactPoint2D[10];//точки контакта на коллайдере

    private readonly Collider2D _collider2D;

    public bool IsGrounded { get; private set; }//свойство для обнаружения контактов. низ, лево, право
    public bool HasLeftContacts { get; private set; }
    public bool HasRightContacts { get; private set; }


    public ContactsPoller(Collider2D collider2D)
    {
        _collider2D = collider2D;
    }

    public void Update()
    {
        //когда приходим в новый кадр, все делаем false
        IsGrounded = false;
        HasLeftContacts = false;
        HasRightContacts = false;

        //занесем данные о контактах в массив c помощью метода GetContacts
        var contactsCount = _collider2D.GetContacts(_contacts);

        for (int i = 0; i < contactsCount; i++)
        {
            var normal = _contacts[i].normal;//проходим по каждому контакту и определяем нормаль
            var rigidbody = _contacts[i].rigidbody;//определяем риджидбоди объекта, с которым мы столкнулись

            if(normal.y > CollisionThresh)//сравниваем, чтобы определить на земле ли мы
                IsGrounded=true;

            if(normal.x > CollisionThresh && rigidbody ==null)//rigidbody ==null понимаем, что мы сталкиваемся не с другим риджидбоди
                HasLeftContacts=true;

            if(normal.x < -CollisionThresh && rigidbody == null)
                HasRightContacts=true;
        }
    }
}
