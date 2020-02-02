using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMGR : MonoBehaviour
{
    public GameObject panel;
    public void SceneChanger()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void PanelToggle()
    {
        if(panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else if (!panel.activeSelf)
        {
            panel.SetActive(true);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
