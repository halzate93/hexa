using System.IO;
using UnityEngine;

public class GetMap
{
	public static string filePath = "C:\\Users\\pcc\\Desktop\\mapsJson.txt";

	public static MapPositions[] getFileData()
	{
		StreamReader reader = new StreamReader(filePath);
		string json = reader.ReadToEnd();

		MapStructure mapStructure = JsonUtility.FromJson<MapStructure>(json);

		return mapStructure.map;
	}
}