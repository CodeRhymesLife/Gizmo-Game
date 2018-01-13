using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int Speed = 1;

	public Rigidbody _rigidbody;

	// Update is called once per frame
	void Start () {
		_rigidbody.velocity = new Vector3(-Speed, 0, 0);
	}
}
