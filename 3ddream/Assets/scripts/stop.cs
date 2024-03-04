using UnityEngine;

public class stop : MonoBehaviour
{
    // Ссылка на Rigidbody
    public Rigidbody rb;

    // Максимальная скорость
    public float maxSpeed = 0f;

    void FixedUpdate()
    {
        // Получаем текущую скорость
        Vector3 velocity = rb.velocity;

        // Если скорость превышает максимальную, уменьшаем ее
        if (velocity.magnitude > maxSpeed)
        {
            // Нормализуем вектор скорости и умножаем на максимальную скорость
            velocity = velocity.normalized * maxSpeed;

            // Устанавливаем новую скорость
            rb.velocity = velocity;
        }
    }
}
