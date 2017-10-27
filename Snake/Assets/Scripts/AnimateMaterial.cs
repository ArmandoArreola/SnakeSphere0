using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateMaterial : MonoBehaviour {
	
	public float scrollSpeed;
	private float offset;
	public Renderer rend;
	private Vector2 vec;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		offset +=(Time.deltaTime*scrollSpeed)/10;
		vec = new Vector2 ((float)(moveHorizontal*scrollSpeed), (float)(moveVertical*scrollSpeed));
		rend.material.SetTextureOffset("_MainTex",vec);
	}
}
