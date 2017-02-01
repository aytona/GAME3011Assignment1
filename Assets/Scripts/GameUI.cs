using UnityEngine;
using UnityEngine.UI;
using Info;

namespace UI {
    public class GameUI : MonoBehaviour {
        public GameObject m_GameManager;
        public Text m_Scans;
        public Text m_Extracts;
        public Text m_Score;
        public Text m_CurrentMode;
        public bool b_ScanMode;
        public bool b_MineMode;

        private StatKeeper m_Stat;

        void Start() {
            m_Stat = m_GameManager.GetComponent<StatKeeper>();
            ScanMode();
        }

        void Update() {
            m_Scans.text = "Scans: " + m_Stat.m_StartingScanAmount.ToString();
            m_Extracts.text = "Extractions: " + m_Stat.m_StartingExtractionAmount.ToString();
            m_Score.text = "Score: " + m_Stat.m_CurrentScore.ToString();
            if (b_MineMode) {
                m_CurrentMode.text = "Extraction Mode";
            }
            if (b_ScanMode) {
                m_CurrentMode.text = "Scanning Mode";
            }
        }

        public void ScanMode() {
            b_MineMode = false;
            b_ScanMode = true;
        }

        public void MineMode() {
            b_MineMode = true;
            b_ScanMode = false;
        }

        public void Quit() {
            Application.Quit();
        }
    }
}