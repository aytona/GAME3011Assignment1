using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour {

    [SerializeField]
    private List<Canvas> m_Canvases;

    public void SwitchScenes(Scene _target) {
        SceneManager.LoadScene(_target.buildIndex);
    }

    public void SwitchCanvas(Canvas _target) {
        foreach (Canvas i in m_Canvases) {
            if (i.enabled) {
                i.enabled = false;
                break;
            }
        }
        _target.enabled = true;
    }

    public void Quit() {
        Application.Quit();
    }
}
