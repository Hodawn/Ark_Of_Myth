using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    // �Ѿ��� �ı���
    public float damage = 20.0f;
    // �Ѿ� �߻� ��
    public float force = 1500.0f;

    private Rigidbody2D rb;
    void Start()
    {
        // Rigidbody ������Ʈ�� ����
        rb = GetComponent<Rigidbody2D>();
        // �Ѿ��� ���� �������� ��(Force)�� ���Ѵ�.
        rb.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * force);
    }
}
