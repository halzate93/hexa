using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class GetMap : MonoBehaviour
{
	private static GetMap instance;

	public static GetMap Instance
	{
		get
		{
			return instance;
		}
	}

	public string filePath = "C:\\Users\\pcc\\Desktop\\mapsJson.txt";

	public event Action<MapPositions[]> OnGotMap;

	private MapPositions[] map;

	public MapPositions[] Map
	{
		get
		{
			return map;
		}
	}

	public void Awake()
	{
		GetPositionsFromServer();
	}

	public void Start()
	{
		instance = this;
	}

	public MapPositions[] getFileData()
	{
		StreamReader reader = new StreamReader(filePath);
		string json = reader.ReadToEnd();

		MapStructure mapStructure = JsonUtility.FromJson<MapStructure>(json);

		return mapStructure.map;
	}

	public void GetPositionsFromServer()
	{
		WWW ww = new WWW("http://175.49.0.10:3000/get");
		StartCoroutine(Call());
	}

	private IEnumerator Call()
	{
		WWW www = new WWW("http://175.49.0.10:3000/get");
		yield return www;

		string json = "{ \"map\":" + www.text + "}";

		MapStructure mapStructure = JsonUtility.FromJson<MapStructure>(json);
		map = mapStructure.map;
		if (OnGotMap != null)
			OnGotMap(map);
	}
}