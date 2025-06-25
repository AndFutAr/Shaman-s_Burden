using UnityEngine;

public class T : MonoBehaviour
{
    [Header("��������� �������")]
    [Tooltip("������������ ���� ������� � ��������")]
    public float swayAngle = 15f;

    [Tooltip("�������� �������")]
    public float swaySpeed = 1f;

    [Tooltip("��������� �������� ��� ��������������")]
    public float randomOffset;

    // ��������� ������� �������
    private Quaternion startRotation;

    void Start()
    {
        // ��������� ��������� ��������
        startRotation = transform.localRotation;

        // ���������� ��������� �������� ����
        randomOffset = Random.Range(0f, 2f * Mathf.PI);
    }

    void Update()
    {
        // ������������ ������� ���� � �������������� ���������
        float angle = swayAngle * Mathf.Sin((Time.time * swaySpeed) + randomOffset);

        // ������� �������� ������ ��� Z
        Quaternion swayRotation = Quaternion.Euler(0, 0, angle);

        // ��������� �������� � �������
        transform.localRotation = startRotation * swayRotation;
    }
}