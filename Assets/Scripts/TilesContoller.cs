using System.Collections;
using UnityEngine;

public class TilesContoller : MonoBehaviour
{
	public float timeToFall = 3f;

	private void OnCollisionEnter(Collision col)
	{
		switch (col.collider.tag)
		{
			case "Player":
				StartFalling();

				break;

			default:
				break;
		}
	}

	public void StartFalling()
	{
		GetComponent<Rigidbody>().isKinematic = false;
	}
}