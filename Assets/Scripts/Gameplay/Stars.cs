using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
	SpriteRenderer sp;


	// Use this for initialization
	void Start()
	{
		sp = GetComponent<SpriteRenderer>();

		float randX = Random.Range(-13.5f, 13.14f);
		float randY = Random.Range(30.0f, 20.0f);
		Vector3 pos = transform.position;
		pos.x = randX;
		pos.y = randY;
		transform.position = pos;

	}

	// Update is called once per frame
	void Update()
	{
		Vector3 scale = transform.localScale;
		scale.x += 0.005f;
		scale.y += 0.005f;
		transform.localScale = scale;

		Color color = sp.color; //Accede al color del objeto
		color.a -= 0.03f;
		sp.color = color;

		if (color.a <= 0)
		{
			Destroy(gameObject);
		}
	}
}
