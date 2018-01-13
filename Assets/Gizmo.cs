using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour {

	public int WingSpeed = 2;

	public float FlapInterval = .5f;

	public Rigidbody RigidBody;

	public KeyCode JumpKey;

	public GameObject HeightGuage;

	public GameObject HeightThreshold;

	private bool _canFlap = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(_canFlap && Input.GetKeyDown(JumpKey))
		{
			TryFlap();
		}
	}

	public void TryFlap()
	{
		float percentOfMaxHeight = Mathf.InverseLerp(0, HeightThreshold.transform.position.y, HeightGuage.transform.position.y);
		float wingSpeed = WingSpeed * (1 - percentOfMaxHeight);

		RigidBody.AddForce(new Vector3(0, wingSpeed, 0));
		_canFlap = false;
		StartCoroutine(WaitToFlap());
	}

	public IEnumerator WaitToFlap()
	{
		yield return new WaitForSeconds(FlapInterval);
		_canFlap = true;
	}
}
