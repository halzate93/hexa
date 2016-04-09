using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class GetMap
{
	public static string filePath = "C:\\Users\\pcc\\Desktop\\mapsJson.txt";

	public static MapStructure getFileData()
	{
		StreamReader reader = new StreamReader(filePath);
		string json = reader.ReadToEnd();

		MapStructure mapStructure = JsonUtility.FromJson<MapStructure>(json);

		foreach (MapPositions position in mapStructure.map)
		{
			Debug.Log(position.x);
		}

		return mapStructure;
	}
}