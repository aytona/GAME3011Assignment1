using UnityEngine;
using System.Collections.Generic;
using Info;
using UI;

namespace Gameplay {
    public class MineArea : MonoBehaviour {
        public int m_Range;
        public bool b_MineMode;

        private int xPos;
        private int yPos;

        private GridGenerator m_Grid;
        private GridScanner m_InstGrid;
        private StatKeeper m_Stat;
        private GameUI m_UI;
        private List<GameObject> m_SurroundingTiles;

        void Start() {
            m_SurroundingTiles = new List<GameObject>();
            m_Grid = FindObjectOfType<GridGenerator>();
            m_InstGrid = FindObjectOfType<GridScanner>();
            m_Stat = FindObjectOfType<StatKeeper>();
            m_UI = FindObjectOfType<GameUI>();
            b_MineMode = false;
            ShowMineRange(xPos, yPos, 2);
        }

        void Update() {
            b_MineMode = m_UI.b_MineMode;
        }

        void OnMouseOver() {
            if (b_MineMode) {
                foreach (GameObject tiles in m_SurroundingTiles) {
                    tiles.GetComponent<SpriteRenderer>().color = new Color(75f / 255f, 75f / 255f, 75f / 255f, 1f);
                }
                gameObject.GetComponent<SpriteRenderer>().color = new Color(75f / 255f, 75f / 255f, 75f / 255f, 1f);
            }
        }

        void OnMouseExit() {
            if (b_MineMode) {
                foreach (GameObject tiles in m_SurroundingTiles) {
                    tiles.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                }
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            }
        }

        void OnMouseDown() {
            if (m_Stat.m_StartingExtractionAmount > 0) {
                foreach (GameObject tiles in m_SurroundingTiles) {
                    if (tiles.activeSelf) {
                        m_Stat.AddScore(tiles.GetComponent<SpriteRenderer>().sprite);
                        tiles.SetActive(false);
                    }
                }
                m_Stat.AddScore(gameObject.GetComponent<SpriteRenderer>().sprite);
                gameObject.SetActive(false);
                m_Stat.m_StartingExtractionAmount--;
            }
        }

        public void SetPos(int x, int y) {
            xPos = x;
            yPos = y;
        }

        private void ShowMineRange(int StartingX, int StartingY, int Range) {
            for (int x = -Range; x < Range + 1; x++) {
                for (int y = -Range; y < Range + 1; y++) {
                    if ((StartingX + x >= 0 && StartingY + y >= 0) && (StartingX + x < m_Grid.xSize && StartingY + y < m_Grid.ySize)) {
                        m_SurroundingTiles.Add(m_InstGrid.m_CurrentGrid[StartingX + x, StartingY + y]);
                    }
                }
            }
        }
    }
}