﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {
	public float Firerate = 0;
	public float damage = 10;
	public LayerMask whatToHit;
	public float effectSpawnrate = 10;

	private float timeToFire = 0;
	float timeToSpawnEffect=0;

	Transform firePoint;
	public Transform BulletTrailPrefab;
	public Transform MuzzleFlashPrefab;
	public GameObject player;


	void Awake () {
		firePoint = transform.FindChild("firepoint");
		if (firePoint == null) {
			Debug.Log ("NO firepoint");
		}
	}
	
	// Update is called once per frame
	public void Fire () {
	//	Shoot ();
		if (Firerate == 0) {
			
				Shoot ();

		}
		else{
			if(Time.time> timeToFire){
				timeToFire = Time.time + 1 / Firerate;
				Shoot ();
			}
		}
	}

	void Shoot(){
		//Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
//		if (player.transform.localScale.x > 0) {
//			firePointPosition.x *= -1;
//		}
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition - firePointPosition, 100,whatToHit);

		if (Time.time >= timeToSpawnEffect) {
			Effect ();
			timeToSpawnEffect = Time.time + 1 / effectSpawnrate;
		}

		Debug.DrawLine (firePointPosition, mousePosition, Color.cyan);
		if (hit.collider != null) {
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
			Debug.Log ("We Hit " + hit.collider.name + " and did " + damage + "damage.");
		}
	}

	void Effect(){

		Instantiate (BulletTrailPrefab, firePoint.position, firePoint.rotation);
		Transform clone = (Transform)Instantiate (MuzzleFlashPrefab, firePoint.position, firePoint.rotation);
		clone.parent = firePoint;
		float size = Random.Range (0.4f, 0.6f);
		clone.localScale = new Vector3 (size, size, size);
		Destroy (clone.gameObject, 0.02f);
	}
}
