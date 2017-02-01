using UnityEngine;

namespace Info {
    public class StatKeeper : MonoBehaviour {
        public int m_StartingScanAmount;
        public int m_StartingExtractionAmount;
        public int m_CurrentScore;

        public Sprite m_FullDiamond;
        public Sprite m_HalfDiamond;
        public Sprite m_FullGold;
        public Sprite m_HalfGold;
        public Sprite m_FullSilver;
        public Sprite m_HalfSilver;
        public Sprite m_FullCoal;
        public Sprite m_HalfCoal;

        private int Diamond = 1000;
        private int Gold = 500;
        private int Silver = 100;
        private int Coal = 10;

        public void AddScore(Sprite _sprite) {
            if (_sprite.name == m_FullDiamond.name) {
                m_CurrentScore += Diamond;
            }
            if (_sprite.name == m_HalfDiamond.name) {
                m_CurrentScore += (int)(Diamond / 2);
            }
            if (_sprite.name == m_FullGold.name) {
                m_CurrentScore += Gold;
            }
            if (_sprite.name == m_HalfGold.name) {
                m_CurrentScore += (int)(Gold / 2);
            }
            if (_sprite.name == m_FullSilver.name) {
                m_CurrentScore += Silver;
            }
            if (_sprite.name == m_HalfSilver.name) {
                m_CurrentScore += (int)(Silver / 2);
            }
            if (_sprite.name == m_FullCoal.name) {
                m_CurrentScore += Coal;
            }
            if (_sprite.name == m_HalfCoal.name) {
                m_CurrentScore += (int)(Coal / 2);
            }
        }
    }
}
