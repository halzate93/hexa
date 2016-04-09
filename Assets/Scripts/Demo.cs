using System.Collections;
using UnityEngine;

public class Demo : MonoBehaviour
{
	[SerializeField]
	public float TranslationZ = 2;

	// Use this for initialization
	private void Start()
	{
	}

	// Update is called once per frame
	private void Update()
	{
		Vector3 vector = new Vector3(0, 0, TranslationZ);
		transform.Translate(vector * Time.deltaTime);
	}
}