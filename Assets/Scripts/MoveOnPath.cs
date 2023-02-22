using UnityEngine;

public class MoveOnPath : MonoBehaviour
{
    [SerializeField] private Transform _path;   // создаем ссылку на компонент Transform объекта путь
    [SerializeField] private float _speed;

    private int _currentPoint;                  // создаем переменную текущей точки положени€ объекта
    private Transform[] _points;                // создаем массив дочерних объектов

    private void Start()
    {
        _points = new Transform[_path.childCount]; // инициализируем массив длиной точек (количество дочерних объектов пути)

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i); // перебираем каждую точку в массиве и даем ей координаты потомка
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint]; // устанавливаем целевую позицию на нулевую €чейку массива
                                                   // (по умолчанию int без инициализации равен 0)

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
