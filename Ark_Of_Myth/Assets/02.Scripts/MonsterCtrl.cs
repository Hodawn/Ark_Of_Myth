using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision coll)
    {

        if (coll.collider.CompareTag("Sword"))
        {
            // �浹�� �Ѿ��� ����
            Destroy(coll.gameObject);
            
        }

    }
}