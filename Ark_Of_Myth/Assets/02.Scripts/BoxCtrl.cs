using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxCtrl : MonoBehaviour
{
   
    public void next()
    {
        SceneManager.LoadScene(1);
    }
}
