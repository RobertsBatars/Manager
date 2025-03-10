using UnityEngine;

public class BackgroundTileManager : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Transform playerTransform;

    private GameObject[,] tiles;
    private Vector2 tileSize;
    private Vector2 backgroundCenter;

    void Start()
    {
        tileSize = GetTileSize(tilePrefab);
        InitTiles();
        backgroundCenter = new Vector2(0, 0);
    }

    private void InitTiles()
    {
        // Spawn 3x3 grid of background tiles behind the player
        tiles = new GameObject[3, 3];

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                Vector3 position = new Vector3(
                    (x - 1) * tileSize.x,
                    (y - 1) * tileSize.y,
                    0
                );

                tiles[x, y] = Instantiate(tilePrefab, position, Quaternion.identity);
            }
        }
    }

    private Vector2 GetTileSize(GameObject prefab)
    {
        var spriteRenderer = prefab.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            return spriteRenderer.bounds.size;
        }
        else
        {
            Debug.LogError("BackgroundTileManager: Tile prefab has no SpriteRenderer component");
            return Vector2.zero;
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        Vector2 movement = (Vector2)playerTransform.position - backgroundCenter;
        if (movement.x > tileSize.x / 2) { ShiftBackground(Vector2.right); backgroundCenter.x += tileSize.x; }
        if (movement.x < -tileSize.x / 2) { ShiftBackground(Vector2.left); backgroundCenter.x -= tileSize.x; }
        if (movement.y > tileSize.y / 2) { ShiftBackground(Vector2.up); backgroundCenter.y += tileSize.y; }
        if (movement.y < -tileSize.y / 2) { ShiftBackground(Vector2.down); backgroundCenter.y -= tileSize.y; }

    }

    private void ShiftBackground(Vector2 direction)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                tiles[i, j].transform.position += new Vector3(
                    direction.x * tileSize.x,
                    direction.y * tileSize.y,
                    0
                );
            }
        }
    }
}
