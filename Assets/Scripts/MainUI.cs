using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour {

    [SerializeField]
    private List<Canvas> m_Canvases;

    void Start() {
        for (int i = 1; i < m_Canvases.Count; ++i) {
            m_Canvases[i].gameObject.SetActive(false);
        }
    }

    public void SwitchScenes(string _target) {
        SceneManager.LoadScene(_target);
    }

    public void SwitchCanvas(Canvas _target) {
        for (int i = 0; i < m_Canvases.Count; ++i) {
            if (m_Canvases[i] == _target) {
                m_Canvases[i].gameObject.SetActive(true);
            } else if (m_Canvases[i].gameObject.activeSelf) {
                m_Canvases[i].gameObject.SetActive(false);
            }
        }
    }

    public void Quit() {
        Application.Quit();
    }
}
