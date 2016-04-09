using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
	Normal = 0,
	Obstacle = 1,
	Crystal = 2
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
	public GameObject[] normalTilePrefabs;

	[SerializeField]
	public GameObject[] elementsPrefabs;

	[SerializeField]
	public Vector2 offsets;

	[SerializeField]
	public float evenDelta;

	[SerializeField]
	public float elementDelta = 1;

	// Use this for initialization
	private void Start()
	{
		//int k = 0;
		//for (int i = 0; i < 10; i++)
		//{
		//	for (int j = 0; j < 10; j++)
		//	{
		//		tiles[k] = new Tile();
		//		tiles[k].x = i;
		//		tiles[k].y = j;
		//		tiles[k].type = TileType.Normal;
		//		k++;
		//	}
		//}

		Adapter adapter = new Adapter();

		Tile[] tiles = adapter.Tiles;

		Map map = new Map();
		map.cells = new GameObject[numberTiles, numberTiles];

		for (int i = 0; i < tiles.Length; i++)
		{
			GameObject tile = normalTilePrefabs[Random.Range(0, normalTilePrefabs.Length - 1)];
			GameObject obj = null;
			switch (tiles[i].type)
			{
				case TileType.Normal:
					break;

				case TileType.Obstacle:
					obj = elementsPrefabs[0];
					break;

				case TileType.Crystal:
					obj = elementsPrefabs[1];
					break;
			}
			if (obj != null)
			{
				Vector3 elePosition = GetEvenOddPosition(tiles[i]);
				elePosition.y += elementDelta;
				GameObject element = (GameObject)GameObject.Instantiate(tile, elePosition, Quaternion.identity);
			}
			Vector3 position = GetEvenOddPosition(tiles[i]);
			GameObject tileObject = (GameObject)GameObject.Instantiate(tile, position, Quaternion.identity);
			map.cells[tiles[i].x, tiles[i].y] = tileObject;
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