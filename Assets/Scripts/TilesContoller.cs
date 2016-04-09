using System.Collections;
using UnityEngine;

public class TilesContoller : MonoBehaviour
{
	public float timeToFall = 3f;

	private bool isFalling = false;

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
		if (!isFalling)
		{
			isFalling = true;
			StartCoroutine(Fall());
		}
	}

	public IEnumerator Fall()
	{
		yield return new WaitForSeconds(timeToFall);

		GetComponent<Rigidbody>().isKinematic = false;

		Destroy(this.gameObject, 4f);
	}
}