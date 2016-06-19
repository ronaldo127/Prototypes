using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class InputHandler : MonoBehaviour {

	public GameObject bullet;
	public float speed;

	private List<GameObject> pool = new List<GameObject>();
	private int i = 0;

	private Vector3 mouseWDownPos;

	void OnMouseUp(){
		Vector3 diffVector = GetMouseWorldPos()-mouseWDownPos;

		GameObject go = pool [(i-1) % 10];
		go.GetComponent<Rigidbody>().velocity = diffVector.normalized*speed;
	}
	
	void OnMouseDown() {

		Vector3 worldPosition = mouseWDownPos = GetMouseWorldPos();
		if (Available()) {
			GameObject go = Instantiate (bullet, worldPosition, Quaternion.Euler(270,0,0)) as GameObject;
			i = pool.Count;
			pool.Add (go);

		} else {
			GameObject go = pool [i % 10];
			go.transform.position = worldPosition;
			Rigidbody rb = go.GetComponent<Rigidbody> ();
			rb.angularVelocity = Vector3.zero;
			rb.velocity = Vector3.zero;
			go.transform.rotation = Quaternion.Euler(270,0,0);
		}
		i++;

	}

	private bool Available(){
		pool.Remove (null);
		return pool.Count < 10;
	} 

	private Vector3 GetMouseWorldPos(){
		float distance = this.transform.position.z-Camera.main.transform.position.z;
		return Camera.main.ScreenToWorldPoint (Input.mousePosition + Vector3.forward * distance);
	}
}
