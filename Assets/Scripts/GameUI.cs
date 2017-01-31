using UnityEngine;
using Gameplay;

namespace UI {
    public class GameUI : MonoBehaviour {
        public GameObject m_GameManager;

        private MineArea m_MineArea;
        private ScanArea m_ScanArea;

        void Start() {
            m_MineArea = m_GameManager.GetComponent<MineArea>();
            m_ScanArea = m_GameManager.GetComponent<ScanArea>();
            m_MineArea.enabled = false;
        }

        public void ScanMode() {
            m_MineArea.enabled = false;
            m_ScanArea.enabled = true;
        }

        public void MineMode() {
            m_MineArea.enabled = true;
            m_ScanArea.enabled = false;
        }

        public void Quit() {
            Application.Quit();
        }
    }
}