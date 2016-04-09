using System.Collections;
using UnityEngine;

public enum TileType
{
	Normal = 0
}

public class Tile
{
	public int x;

	public int y;

	public TileType type;
}

internal class Map
{
	public GameObject[,] cells;
}

public class InitialMapCreator : MonoBehaviour
{
	[SerializeField]
	public int numberTiles;

	[SerializeField]
	public GameObject normalTile;

	[SerializeField]
	public Vector2 offsets;

	[SerializeField]
	public float evenDelta;

	// Use this for initialization
	private void Start()
	{
		Tile[] tiles = new Tile[numberTiles];

		int k = 0;
		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < 10; j++)
			{
				tiles[k] = new Tile();
				tiles[k].x = i;
				tiles[k].y = j;
				tiles[k].type = TileType.Normal;
				k++;
			}
		}

		Map map = new Map();
		map.cells = new GameObject[numberTiles, numberTiles];

		for (int i = 0; i < tiles.Length; i++)
		{
			switch (tiles[i].type)
			{
				case TileType.Normal:
					Vector3 position = GetEvenOddPosition(tiles[i]);
					GameObject tileObject = (GameObject)GameObject.Instantiate(normalTile, position, Quaternion.identity);
					map.cells[tiles[i].x, tiles[i].y] = tileObject;
					break;
			}
		}
	}

	// Update is called once per frame
	private void Update()
	{
	}

	private Vector3 GetEvenOddPosition(Tile tile)
	{
		float x, y;
		x = tile.x * offsets.x;

		if (tile.x % 2 == 0) //par
		{
			y = tile.y * offsets.y - evenDelta;
		}
		else { //impar
			y = tile.y * offsets.y;
		}

		return new Vector3(x, 0, y);
	}
}