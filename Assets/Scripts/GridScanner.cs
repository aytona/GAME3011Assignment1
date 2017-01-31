using UnityEngine;
using System;

namespace Gameplay {
    [RequireComponent(typeof(GridGenerator))]
    public class GridScanner : MonoBehaviour {
        [Serializable]
        public class TileSets {
            public Sprite m_Max;
            public Sprite m_Min;
        }

        public TileSets[] m_Tiles;
        public Sprite m_DefaultTile;

        private GridGenerator m_GridGenerator;
        private int[,] m_CurrentGrid;

        void Start() {
            m_GridGenerator = GetComponent<GridGenerator>();

        }

        void InitializeGrid() {
            //int xPos;
            //int yPos;
            for (int x = 0; x < m_GridGenerator.xSize; x++) {
                for (int y = 0; y < m_GridGenerator.ySize; y++) {

                }
            }
        }
    }
}
