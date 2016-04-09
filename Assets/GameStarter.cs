using System.Collections;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
	public GameObject prefabToInstantiate;

	public Transform initialTransform;

	// Use this for initialization
	private void Start()
	{
	}

	// Update is called once per frame
	private void Update()
	{
	}

	private void InstantiateCharacter()
	{
		PhotonNetwork.Instantiate(prefabToInstantiate.name, initialTransform.position, initialTransform.rotation, 0);
	}
}