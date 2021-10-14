using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneManage : MonoBehaviour
{
    public void OrderScene()
    {
        SceneManager.LoadScene("OrderScene");
    }

    public void MixingScene()
    {
        SceneManager.LoadScene("MixingScene");
    }
}