using System;

public class Adapter
{
	public event Action<Tile[]> OnBuiltTiles;

	private Tile[] tiles;

	public Tile[] Tiles
	{
		get
		{
			return tiles;
		}
	}

	public Adapter()
	{
		GetMap.Instance.OnGotMap += BuildTiles;
	}

	private void BuildTiles(MapPositions[] maps)
	{
		Tile[] tiles = new Tile[maps.Length];
		for (int i = 0; i < maps.Length; i++)
		{
			Tile tile = new Tile();
			tile.x = maps[i].x;
			tile.y = maps[i].y;
			tile.type = (TileType)maps[i].type;
			tiles[i] = tile;
		}
		this.tiles = tiles;
		if (OnBuiltTiles != null)
			OnBuiltTiles(tiles);
	}
}