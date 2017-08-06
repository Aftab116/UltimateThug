using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePathSpawnner : MonoBehaviour {
    public Transform destination;
    public PathedProjectile projectile;

    public float speed;
    public float fireRate;

    private float nextShotInSeconds;
    public Animator anim;

	// Use this for initialization
	void Start () {
        nextShotInSeconds = fireRate;
	}
	
	// Update is called once per frame
	void Update () {
        if ((nextShotInSeconds -= Time.deltaTime) > 0)
            return;

        nextShotInSeconds = fireRate;
        var proj = (PathedProjectile)Instantiate(projectile, transform.position, transform.rotation);
        proj.Initialize(destination, speed);

        if (anim != null)
        {
            anim.SetTrigger("Fire");
        }
	}

    private void OnDrawGizmos()
    {
        if (destination == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, destination.position);
    }
}
