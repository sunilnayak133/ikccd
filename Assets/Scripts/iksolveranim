using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iksolver : MonoBehaviour {

	// Array to hold all the joints
	// index 0 - root
	// index END - End Effector
	public GameObject[] joints;

  public Quaternion[] rot;

  // The target for the IK system
	public GameObject targ;

	// To check if the target is reached at any point
	public bool done = false;
	// To store the position of the target
	private Vector3 tpos;

	// Max number of tries before the system gives up (Maybe 10 is too high?)
	[SerializeField]
	private int Mtries = 10;
	// The number of tries the system is at now
	[SerializeField]
	private int tries = 0;
	
    [SerializeField]
	// the range within which the target will be assumed to be reached
	private float epsilon = 0.1f;


	// Initializing the variables
	void Start () {

        rot = new Quaternion[joints.Length];
        for(int i=0;i<joints.Length;i++)
        {
            rot[i] = joints[i].GetComponent<Transform>().rotation;
        }
		    tpos = targ.transform.position;
	}
	
	// Running the solver - all the joints are iterated through once every frame
	void LateUpdate () {

        for (int i = 0; i < joints.Length; i++)
        {
             joints[i].GetComponent<Transform>().rotation = rot[i];
        }

        
        for (int j = 0; j < Mtries; j++)
        {
            for (int i = joints.Length - 2; i >= 0; i--)
            {
                // The vector from the ith joint to the end effector
                Vector3 r1 = joints[joints.Length - 1].transform.position - joints[i].transform.position;
                // The vector from the ith joint to the target
                Vector3 r2 = targ.transform.position - joints[i].transform.position;

                Quaternion q = Quaternion.FromToRotation(r1, r2);
                joints[i].transform.rotation = q * joints[i].transform.rotation;
                
            }
        }
    
     

	}
 
}
