using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour 
{
	public Transform pivot;
	public float springRange, maxVel;
	public bool wasLaunched = false;
	Rigidbody2D rb;
	bool canDrag = true;
	Vector3 dis;

	// Use this for initialization
	void Start () 
	{
		PlayerPrefs.SetInt("wasLaunched", 0);
		rb = GetComponent<Rigidbody2D>();
		rb.bodyType = RigidbodyType2D.Kinematic;
	}

	// It is executed when you keep the mouse clicked and move it.
	void OnMouseDrag() 
	{
		if(!canDrag)
		{
			return;
		}
		else
		{
			var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			dis = pos - pivot.position;	
			dis.z = 0;
			if(dis.magnitude > springRange)
			{
				dis = dis.normalized * springRange;
			}
			transform.position = dis + pivot.position;
		}
	}

	//It is executed when you stop clicking the mouse.
	void OnMouseUp()
	{
		if(!canDrag)
			return;
		canDrag = false;
		rb.bodyType = RigidbodyType2D.Dynamic;
		rb.velocity = -dis.normalized * maxVel * dis.magnitude / springRange;
		PlayerPrefs.SetInt("wasLaunched", 1);
	}
}
