
using UnityEngine;

public class ParalaxManager 
{
    //будут поступать данные о камере и фоне через конструктор класса

    private const float _coef = 0.3f;//коэффициент с которым наш фон будет смещаться относительно камеры

    private readonly Camera _camera;
    private readonly Transform _backTransform;
    private readonly Vector3 _backStartPosition;
    private readonly Vector3 _cameraStartPosition;

    public ParalaxManager(Camera camera, Transform backTransform)//будем запускать в Старте класса Лессонс
    {
        _camera = camera;
        _backTransform = backTransform;
        _backStartPosition = backTransform.position; //стартовая позиция. Чтобы при старте ничего не сбилось
        _cameraStartPosition = camera.transform.position;
    }

   public void Update()
    {
        _backTransform.position = _backStartPosition + (_camera.transform.position - _cameraStartPosition) * _coef;
    }
}
