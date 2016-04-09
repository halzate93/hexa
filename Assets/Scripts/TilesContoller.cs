using System;
using System.Collections;
using UnityEngine;

public class TilesContoller : MonoBehaviour
{
	public float timeToFall = 3f;

	public float shakeStrenght;

	public new Rigidbody rigidbody;

	private bool isFalling;

	private Vector3 originalPosition;

	private void OnCollisionEnter(Collision other)
	{
		switch (other.collider.tag)
		{
			case "Player":
				if (!isFalling)
					StartFalling();

				break;

			default:
				break;
		}
	}

	private void StartFalling()
	{
		originalPosition = transform.position;
		isFalling = true;
		StartCoroutine(Fall());
	}

	private void Update()
	{
		if (isFalling)
		{
			Vector3 translation = Vector3.up * UnityEngine.Random.Range(-shakeStrenght, shakeStrenght);
			transform.Translate(translation);
		}
	}

	public IEnumerator Fall()
	{
		yield return new WaitForSeconds(timeToFall);
		isFalling = false;
		rigidbody.isKinematic = false;

		Destroy(this.gameObject, 4f);
	}
}