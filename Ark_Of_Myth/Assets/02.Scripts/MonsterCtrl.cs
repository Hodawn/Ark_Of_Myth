using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MonsterCtrl : MonoBehaviour
{
    private readonly int hashDie = Animator.StringToHash("Die");
    public int hp = 100;

    public float GenTime;
    public SpriteRenderer spriteRenderer;

    public Slider HealthBar;

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


    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.collider.CompareTag("SWORD"))
        {
            hp -= 10;
            HealthBar.value = (float)hp/100.0f;

            if (hp <= 0)
            {
                SceneManager.LoadScene("EndingScene");
            }
        }

    }
    
}
