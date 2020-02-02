using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMGR : MonoBehaviour
{

    public void SceneChanger()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
