using UnityEngine;
using System.Collections;

public class demo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public float moveSpeed = 10f;
	public float turnSpeed = 50f;
	
	
	void Update ()
	{
		if(samplechat1.pythonServer.val.Equals("N"))
		if(samplechat1.pythonServer.val.Equals("up"))
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		
		if(samplechat1.pythonServer.val.Equals("down"))
			transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
		
		if(serverForRpi.csServer.val.Equals("left"))
			transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
		
		if(samplechat1.pythonServer.val.Equals("right"))
			transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
	}
}
