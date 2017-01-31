using UnityEngine;

namespace Gameplay {
    public class GridGenerator : MonoBehaviour {
        public int xSize;
        public int ySize;
        public int ResourceMinRange;
        public int ResourceMaxRange;

        private int[,] grid;
        private int MaxResources;

        void Start() {
            // Initialize the grid
            grid = new int[xSize, ySize];
            ClearGrid();
            GenerateGrid();
        }

        // Gets the generated grid
        public int[,] GetGrid() {
            if (grid == null) {
                GenerateGrid();
            }
            return grid;
        }

        // Generates the grid
        public void GenerateGrid() {
            // Marks the location of where the max resource will be at
            MaxResources = Random.Range(ResourceMinRange, ResourceMaxRange);
            for (int x = 0; x < MaxResources; ++x) {
                bool CheckForDups = true;
                while (CheckForDups) {
                    int randX = Random.Range(0, xSize);
                    int randY = Random.Range(0, ySize);
                    if (grid[randX, randY] != 3) {
                        CheckForDups = false;
                        grid[randX, randY] = 3;
                        IncreaseGridValue(randX, randY, 2);
                        IncreaseGridValue(randX, randY, 1);
                    }
                }
            }
        }

        // Increases the value of the element around the starting location
        public void IncreaseGridValue(int StartingX, int StartingY, int Range) {
            for (int x = -Range; x < Range + 1; x++) {
                for (int y = -Range; y < Range + 1; y++) {
                    if (x == 0 && y == 0) {
                        // Do nothing
                    }
                    // Bound checks
                    else if((StartingX + x >= 0 && StartingY + y >= 0) && (StartingX + x < xSize && StartingY + y < ySize)) {
                        // Clamp the max value of a tile to be at 3 (which is pre-deterimed before this function)
                        if (grid[StartingX + x, StartingY + y] + 1 < 3) {
                            grid[StartingX + x, StartingY + y]++;
                        }
                    }
                }
            }
        }

        // Clears the whole grid
        public void ClearGrid() {
            for (int x = 0; x < xSize; x++) {
                for (int y = 0; y < ySize; y++) {
                    grid[x, y] = 0;
                }
            }
        }

        // For testing purpose to check if the grid is working as intended
        private void TestGrid() {
            string printGrid = "";
            for (int x = 0; x < xSize; x++) {
                for (int y = 0; y < ySize; y++) {
                    printGrid += grid[x, y].ToString();
                }
                printGrid += "\n";
           }
            Debug.Log(printGrid);
        }
    }
}