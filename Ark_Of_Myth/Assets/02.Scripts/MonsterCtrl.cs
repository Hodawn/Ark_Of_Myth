using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    private readonly int hashDie = Animator.StringToHash("Die");
    private int hp = 100;

    public float GenTime;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update

    private void Start()
    {
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        GenTime -= Time.deltaTime;

        if(GenTime <= 0)
        {
            spriteRenderer.enabled = true;
        }
    }


    void OnCollisionEnter(Collision coll)
    {

        if (coll.collider.CompareTag("Sword"))
        {
            // 충돌한 총알을 삭제
            Destroy(coll.gameObject);
            
        }

    }
    
}
