using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFire : MonoBehaviour
{
    // �浹�� ������ �� �߻��ϴ� �̺�Ʈ
    void OnCollisionEnter(Collision coll)
    {
        // �浹�� ���ӿ�����Ʈ�� �±װ� ��
        if (coll.collider.CompareTag ("Fire"))
        {
            // �浹�� ���ӿ�����Ʈ ����
            Destroy(coll.gameObject);
        }
    }
}
