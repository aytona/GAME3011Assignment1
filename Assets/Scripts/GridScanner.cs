using System.Collections.Generic;
using UnityEngine;
using System;

namespace Gameplay {
    [RequireComponent(typeof(GridGenerator))]
    public class GridScanner : MonoBehaviour {
        [Serializable]
        public class TileSets {
            public string m_TileName;
            public Sprite m_Max;
            public Sprite m_Min;
        }

        public TileSets[] m_Tiles;
        public Sprite m_DefaultTile;

        // TODO: Just get sprite size and calculate offset
        public float StartX;
        public float StartY;
        public float XOffset;
        public float YOffset;

        private GridGenerator m_GridGenerator;
        private GameObject[,] m_CurrentGrid;
        private List<GameObject> m_Minables;

        void Start() {
            m_Minables = new List<GameObject>();
            m_GridGenerator = GetComponent<GridGenerator>();
            m_CurrentGrid = new GameObject[m_GridGenerator.xSize, m_GridGenerator.ySize];
            InitializeGrid();
        }

        private void InitializeGrid() {
            for (int y = 0; y < m_GridGenerator.ySize; y++) {
                for (int x = 0; x < m_GridGenerator.xSize; x++) {
                    InstantiateForeground(x, y);
                    InstantiateBackground(x, y);
                }
            }
            SetMinableSprites();
        }

        // Instantiates the default tileset (Scannable tiles)
        private void InstantiateForeground(int x, int y) {
            var tile = new GameObject();
            tile.name = "Scan(" + x.ToString() + "," + y.ToString() + ")";
            tile.transform.position = new Vector2(StartX + (x * XOffset), StartY + (y * YOffset));
            tile.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
            tile.AddComponent<SpriteRenderer>();
            tile.GetComponent<SpriteRenderer>().sprite = m_DefaultTile;
            tile.layer = 9;
            tile.tag = "Scannable";
            tile.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
        }

        // Instantiates the generate tileset (Minable tiles)
        private void InstantiateBackground(int x, int y) {
            var tile = new GameObject();
            tile.transform.position = new Vector2(StartX + (x * XOffset), StartY + (y * YOffset));
            tile.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
            tile.AddComponent<SpriteRenderer>();
            tile.layer = 10;
            tile.tag = "Minable";
            tile.GetComponent<SpriteRenderer>().sortingLayerName = "Underground";
            if (m_GridGenerator.grid[x, y] == 3) {
                int rand = UnityEngine.Random.Range(0, m_Tiles.Length - 1);
                tile.name = m_Tiles[rand].m_TileName;
            } else if (m_GridGenerator.grid[x, y] == 1) {
                tile.name = m_Tiles[m_Tiles.Length - 1].m_TileName;
                tile.GetComponent<SpriteRenderer>().sprite = m_Tiles[m_Tiles.Length - 1].m_Min;
            } else if (m_GridGenerator.grid[x, y] == 0) {
                tile.name = "Default";
            } else {
                tile.name = "Unknown";
            }
            m_CurrentGrid[x, y] = tile;
        }

        private void SetMinableSprites() {
            // There might be an easier way to do this, but I'm drawing a blank at the moment
            // Only 2 hours left until deadline
            for (int y = 0; y < m_GridGenerator.ySize; y++) {
                for (int x = 0; x < m_GridGenerator.xSize; x++) {
                    if (m_CurrentGrid[x, y].name == "Unknown") {
                        int Range = 1;
                        for (int xRange = -Range; xRange < Range + 1; xRange++) {
                            for (int yRange = -Range; yRange < Range + 1; yRange++) {
                                if (xRange == 0 && yRange == 0) {
                                    // Do nothing
                                }
                                if ((x + xRange >= 0 && y + yRange >= 0) && (x + xRange < m_GridGenerator.xSize && y + yRange < m_GridGenerator.ySize)) {
                                    if (m_GridGenerator.grid[x + xRange, y + yRange] == 3) {
                                        m_CurrentGrid[x, y].name = m_CurrentGrid[x + xRange, y + yRange].name;
                                        foreach (TileSets tiles in m_Tiles) {
                                            if (m_CurrentGrid[x, y].name == tiles.m_TileName) {
                                                m_CurrentGrid[x, y].GetComponent<SpriteRenderer>().sprite = tiles.m_Min;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (m_CurrentGrid[x, y].name == "Unknown") {
                            m_CurrentGrid[x, y].GetComponent<SpriteRenderer>().sprite = m_Tiles[m_Tiles.Length - 1].m_Max;
                        }
                    }
                    if (m_CurrentGrid[x ,y].name == "Default") {
                        m_CurrentGrid[x, y].GetComponent<SpriteRenderer>().sprite = m_DefaultTile;
                    }
                    else if (m_GridGenerator.grid[x, y] == 3){
                        foreach (TileSets tiles in m_Tiles) {
                            if (m_CurrentGrid[x, y].name == tiles.m_TileName) {
                                m_CurrentGrid[x, y].GetComponent<SpriteRenderer>().sprite = tiles.m_Max;
                            }
                        }
                    }
                }
            }
        }
    }
}
