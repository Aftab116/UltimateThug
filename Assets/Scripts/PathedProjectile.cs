using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathedProjectile : MonoBehaviour {

    private Transform destination;
    private float speed;


    public void Initialize(Transform dest,float sp)
    {
        destination = dest;
        speed = sp;

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, destination.position, Time.deltaTime * speed);

        var distanceSquared = (destination.transform.position - transform.position).sqrMagnitude;
        if(distanceSquared> .01f * .01f)
        {
            return;
        }
        Destroy(gameObject);
	}
}
