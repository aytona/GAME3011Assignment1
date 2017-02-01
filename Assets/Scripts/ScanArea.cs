using UnityEngine;
using Info;
using UI;
using System.Collections.Generic;

namespace Gameplay {
    public class ScanArea : MonoBehaviour {
        public int m_Range;
        public bool b_ScanMode;

        private int xPos;
        private int yPos;

        private GridGenerator m_Grid;
        private GridScanner m_InstGrid;
        private StatKeeper m_Stat;
        private GameUI m_UI;
        private List<GameObject> m_SurroundingTiles;

        void Start() {
            m_Stat = FindObjectOfType<StatKeeper>();
            m_SurroundingTiles = new List<GameObject>();
            m_Grid = FindObjectOfType<GridGenerator>();
            m_InstGrid = FindObjectOfType<GridScanner>();
            m_UI = FindObjectOfType<GameUI>();
            b_ScanMode = true;
            ShowScanRange(xPos, yPos, 2);
        }

        void Update() {
            b_ScanMode = m_UI.b_ScanMode;
        }

        void OnMouseOver() {
            if (b_ScanMode) {
                foreach (GameObject tiles in m_SurroundingTiles) {
                    tiles.GetComponent<SpriteRenderer>().color = new Color(75f / 255f, 75f / 255f, 75f / 255f, 1f);
                }
                gameObject.GetComponent<SpriteRenderer>().color = new Color(75f / 255f, 75f / 255f, 75f / 255f, 1f);
            }
        }

        void OnMouseExit() {
            if (b_ScanMode) {
                foreach (GameObject tiles in m_SurroundingTiles) {
                    tiles.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                }
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            }
        }

        void OnMouseDown() {
            if (m_Stat.m_StartingScanAmount > 0) {
                foreach (GameObject tiles in m_SurroundingTiles) {
                    if (tiles.activeSelf) {
                        tiles.SetActive(false);
                    }
                }
                gameObject.SetActive(false);
                m_Stat.m_StartingScanAmount--;
            }
        }

        public void SetPos(int x, int y) {
            xPos = x;
            yPos = y;
        }

        private void ShowScanRange(int StartingX, int StartingY, int Range) {
            for (int x = -Range; x < Range + 1; x++) {
                for (int y = -Range; y < Range + 1; y++) {
                    if ((StartingX + x >= 0 && StartingY + y >= 0) && (StartingX + x < m_Grid.xSize && StartingY + y < m_Grid.ySize)) {
                        m_SurroundingTiles.Add(m_InstGrid.m_ScanGrid[StartingX + x, StartingY + y]);
                    } 
                }
            }
        }
    }
}
