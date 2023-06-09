using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    private readonly int hashDie = Animator.StringToHash("Die");
    private int hp = 100;
    // Start is called before the first frame update
 

    void OnCollisionEnter(Collision coll)
    {

        if (coll.collider.CompareTag("Sword"))
        {
            // 충돌한 총알을 삭제
            Destroy(coll.gameObject);
            
        }

    }
    
}
