using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jointrotate : MonoBehaviour {

    private float time = 0f;
    private int intime = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (intime > time)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, time));
        }

        time += Time.deltaTime;
        intime = ((int)time) + 1;

	}
}
