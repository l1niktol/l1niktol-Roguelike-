using UnityEngine;

public class stop : MonoBehaviour
{
    // ������ �� Rigidbody
    public Rigidbody rb;

    // ������������ ��������
    public float maxSpeed = 0f;

    void FixedUpdate()
    {
        // �������� ������� ��������
        Vector3 velocity = rb.velocity;

        // ���� �������� ��������� ������������, ��������� ��
        if (velocity.magnitude > maxSpeed)
        {
            // ����������� ������ �������� � �������� �� ������������ ��������
            velocity = velocity.normalized * maxSpeed;

            // ������������� ����� ��������
            rb.velocity = velocity;
        }
    }
}
