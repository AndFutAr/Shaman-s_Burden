using UnityEngine;

public class T : MonoBehaviour
{
    [Header("Настройки качания")]
    [Tooltip("Максимальный угол наклона в градусах")]
    public float swayAngle = 15f;

    [Tooltip("Скорость качания")]
    public float swaySpeed = 1f;

    [Tooltip("Случайное смещение для естественности")]
    public float randomOffset;

    // Начальный поворот объекта
    private Quaternion startRotation;

    void Start()
    {
        // Сохраняем начальное вращение
        startRotation = transform.localRotation;

        // Генерируем случайное смещение фазы
        randomOffset = Random.Range(0f, 2f * Mathf.PI);
    }

    void Update()
    {
        // Рассчитываем текущий угол с использованием синусоиды
        float angle = swayAngle * Mathf.Sin((Time.time * swaySpeed) + randomOffset);

        // Создаем вращение вокруг оси Z
        Quaternion swayRotation = Quaternion.Euler(0, 0, angle);

        // Применяем вращение к объекту
        transform.localRotation = startRotation * swayRotation;
    }
}