// Top Down Starter Kit
// By J. Navarro-Fennell
// Class: Player_Rotator
// Description:

using UnityEngine;
using System.Collections;

public class Player_Rotator : MonoBehaviour 
{
	public float rotationSpeed = 10f;
	
	private Vector3 dir;
	
	void Start () 
    {
		dir = Vector3.forward + Vector3.up;
	}
	
	void Update ()
    {
        // Calculo de la dirección horizontal
        if (Input.GetAxis("Horizontal") == 1f)
        {
            dir += Vector3.right;
        } 
        else if(Input.GetAxis("Horizontal") == -1f) 
        {
            dir += Vector3.left;
        }

        // Calculo de la dirección vertical
        if (Input.GetAxis("Vertical") == 1f)
        {
            dir += Vector3.forward;
        }
        else if (Input.GetAxis("Vertical") == -1f)
        {
            dir += Vector3.back;
        }

        // Applicación de la rotación del personaje
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, NormalizeQuaternion(Quaternion.LookRotation(dir)), rotationSpeed);
        }

        dir = Vector3.zero;
    }

	Quaternion NormalizeQuaternion (Quaternion q) 
    {
		float sum = 0;
		for (int i = 0; i < 4; ++i) 
        {
			sum += q[i] * q[i];
		}
		float magnitudeInverse = 1 / Mathf.Sqrt(sum);

		for (int i = 0; i < 4; ++i) 
        {
			q[i] *= magnitudeInverse;
		}   
		return q;
	}
}
