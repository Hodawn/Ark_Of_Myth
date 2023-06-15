using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCtrl : MonoBehaviour
{

    public int spearState = 0;

    public float speed = 1.0f;

    public float resetTime = 2.0f;
    public float TimeSet = 0.0f;

    public float damage = 30.0f;

    void Start()
    {
      
    }


    // Update is called once per frame
    void Update()
    {
        TimeSet += Time.deltaTime;

        if(spearState == 0)
        {
            gameObject.transform.position += new Vector3(0.0f, 1.0f, 0.0f) * speed * Time.deltaTime;
        }
        else
        {
            gameObject.transform.position -= new Vector3(0.0f, 1.0f, 0.0f) * speed * Time.deltaTime;
        }       

        if (resetTime <= TimeSet)
        {
            TimeSet = 0.0f;          

            if (spearState == 0)
            {
                spearState = 1;
            }
            else
            {
                spearState = 0;
            }
            

        }
    }
}
