using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    // ÃÑ¾ËÀÇ ÆÄ±«·Â
    public float damage = 20.0f;
    public float speed = 10.0f;

    public float resetTime = 2.0f;
    public float TimeSet = 0.0f;

    public Vector3 FirstPostion;
    void Start()
    {
        FirstPostion = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        TimeSet += Time.deltaTime;
        gameObject.transform.position -= new Vector3(0.0f, 1.0f, 0.0f) * speed * Time.deltaTime;

        if (resetTime <= TimeSet)
        {
            TimeSet = 0.0f;
            this.gameObject.transform.position = FirstPostion;
        }
    }
}
