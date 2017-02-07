using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iksolver : MonoBehaviour {

    public GameObject[] joints;
    public GameObject targ;
    public float[] theta;

    [SerializeField]
    private float[] sin;
    [SerializeField]
    private float[] cos; 

    public bool done = false;
    private Vector3 tpos;

    [SerializeField]
    private int Mtries = 10;
    [SerializeField]
    private int tries = 0;


	// Use this for initialization
	void Start () {
        theta = new float[joints.Length];
        sin = new float[joints.Length];
        cos = new float[joints.Length];
        tpos = targ.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if (!done)
        {
            if (tries <= Mtries)
            {
                for (int i = joints.Length - 2; i >= 0; i--)
                {
                    Vector3 r1 = joints[joints.Length - 1].transform.position - joints[i].transform.position;
                    Vector3 r2 = targ.transform.position - joints[i].transform.position;
                    //if (r1.magnitude <= 0.001f)
                    //    continue;
                    //if (r2.magnitude <= 0.001f)
                    //    continue;
                    if (r1.magnitude * r2.magnitude <= 0.001f)
                    {
                        cos[i] = 1;
                        sin[i] = 0;
                    }
                    else
                    {
                        cos[i] = Vector3.Dot(r1, r2) / (r1.magnitude * r2.magnitude);
                        if (Mathf.Abs(cos[i]) <= 0.0001f || Mathf.Abs(cos[i]) >= 0.9999f)
                            continue;
                        sin[i] = (Vector3.Cross(r1, r2)).magnitude / (r1.magnitude * r2.magnitude);
                        if (Mathf.Abs(sin[i]) <= 0.0001f || Mathf.Abs(sin[i]) >= 0.9999f)
                            continue;
                    }
                    Vector3 axis = (Vector3.Cross(r1, r2)) / (r1.magnitude * r2.magnitude);
                    axis = axis.normalized;
                    //Debug.DrawRay(joints[i].transform.position, axis*5, Color.green,1);
                    //Debug.DrawRay(joints[i].transform.position, r1*5, Color.blue,1);
                    //Debug.DrawRay(joints[i].transform.position, r2*5, Color.red,1);

                    //theta[i] = Mathf.Atan2(sin[i], cos[i]);
                    theta[i] = Mathf.Acos(Mathf.Max(-1, Mathf.Min(1, cos[i])));
                    if (sin[i] < 0.0f)
                        theta[i] = -theta[i];
                    theta[i] = (float)SimpleAngle(theta[i]) * Mathf.Rad2Deg;
                    joints[i].transform.Rotate(axis, theta[i]);

                }

                tries++;
            }
        }

        float x = Mathf.Abs(joints[joints.Length-1].transform.position.x - targ.transform.position.x);
        float y = Mathf.Abs(joints[joints.Length-1].transform.position.y - targ.transform.position.y);
        float z = Mathf.Abs(joints[joints.Length-1].transform.position.z - targ.transform.position.z);
        if (x < 0.1f && y < 0.1f && z < 0.1f)
        {
            done = true;
        }
        else
        {
            done = false;
        }

        if(targ.transform.position!=tpos)
        {
            tries = 0;
            tpos = targ.transform.position;
        }


        

    }

    double SimpleAngle(double theta)
    {
        theta = theta % (2.0 * Mathf.PI);
        if (theta < -Mathf.PI)
            theta += 2.0 * Mathf.PI;
        else if (theta > Mathf.PI)
            theta -= 2.0 * Mathf.PI;
        return theta;
    }
}
