using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Minesweeper2D
{
    public class Grid : MonoBehaviour
    {
        public GameObject tilePrefab;
        public int width = 10;
        public int height = 10;
        public float spacing = .155f;
        public GameObject tile;

        private float offSet = .5f;
        private Tile[,] tiles;
        private Ray mouseRay;

        // Functionality for spawning tiles
        Tile SpawnTile(Vector3 pos)
        {
            // Clone tile prefab
            GameObject clone = Instantiate(tilePrefab);
            clone.transform.position = pos; // Position tile
            Tile currentTile = clone.GetComponent<Tile>(); // Get Tile component
            return currentTile; // Return it
        }

        // Spawns tiles in a grid-like pattern
        void GenerateTiles()
        {
            // Create new 2D array of size width x height
            tiles = new Tile[width, height];

            // Loop through the entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Store half size for later use
                    Vector2 halfSize = new Vector2(width / 2, height / 2);
                    // Pivot tiles around Grid
                    Vector2 pos = new Vector2(x - (halfSize.x - offSet),
                                              y - (halfSize.y - offSet));
                    // Apply spacing
                    pos *= spacing;
                    // Spawn the tile
                    Tile tile = SpawnTile(pos);
                    // Attach newly spawned tile to
                    tile.transform.SetParent(transform);
                    // Store it's array coordinates within itself for future reference
                    tile.x = x;
                    tile.y = y;
                    // Store tile in array at those coordinates
                    tiles[x, y] = tile;
                }
            }
        }

        // Use this for initialization
        void Start()
        {
            // Generate tiles on startup
            GenerateTiles();
        }

        // Update is called once per frame
        void Update()
        {

        }

        // Count adjacent mines at element
        public int GetAdjacentMineCountAt(Tile t)
        {
            int count = 0;
            // Loop through all elements and have each axis go between -1 to 1
            for (int x = -1; x <= 1; x++)
            {
                // Calculate desired coordinates from ones attained
                int desiredX = t.x + x;

                // IF desiredX is within range of tiles array length
                    // IF the element at index is a mine
                        // Increment count 1
            }
            return count;
        }

        void DestroyTile()
        {
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit))
            {
                
                    tile.SetActive(false);
                
            }
        }

    }
}