using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;
public class OnJoinedInstantiateAndSetCamera : MonoBehaviour {

	public Transform SpawnPosition;
	public float PositionOffset = 2.0f;
	public GameObject[] PrefabsToInstantiate;   // set in inspector
	public FollowTarget cameraFollow;

	public void OnJoinedRoom()
	{
		foreach (GameObject o in this.PrefabsToInstantiate)
		{
			Debug.Log("Instantiating: " + o.name);

			Vector3 spawnPos = Vector3.up;
			if (this.SpawnPosition != null)
			{
				spawnPos = this.SpawnPosition.position;
			}

			Vector3 random = Random.insideUnitSphere;
			random.y = 0;
			random = random.normalized;
			Vector3 itempos = spawnPos + this.PositionOffset * random;

			GameObject instance = PhotonNetwork.Instantiate(o.name, itempos, Quaternion.identity, 0);
			cameraFollow.target = instance.transform;
		}
	}
}
