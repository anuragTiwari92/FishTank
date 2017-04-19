using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour {
	int waveNum;
	public float distX, distZ;
	public float[] waveAmp;
	public float mag;

	Mesh mesh;
	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshFilter> ().mesh;
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 8; i++) 
		{
			waveAmp [i] = GetComponent<Renderer> ().material.GetFloat ("_WaveAmp" + (i + 1));
			if (waveAmp [i] > 0) 
			{
				GetComponent<Renderer> ().material.SetFloat ("_WaveAmp" + (i + 1), waveAmp[i] * 0.98f);

			}
			if (waveAmp [i] < 0.05) 
			{
				GetComponent<Renderer> ().material.SetFloat ("_WaveAmp" + (i + 1), 0);
			}
		}
		
	}

	void OnCollisionEnter(Collision col){
		if (col.rigidbody) 
		{	
			waveNum++;
			if (waveNum == 9) 
			{
				waveNum = 1;
			}
			waveAmp [waveNum - 1] = 0;
			distX = this.transform.position.x - col.gameObject.transform.position.x;
			distZ = this.transform.position.z - col.gameObject.transform.position.z;

			//send updated numbers to shader
			//renderer.material.SetFloat("_OffsetX" + waveNum, distX);
			GetComponent<Renderer>().material.SetFloat("_OffsetX" + waveNum, distX / mesh.bounds.size.x * 2.5f);
			GetComponent<Renderer>().material.SetFloat("_OffsetZ" + waveNum, distZ / mesh.bounds.size.z * 2.5f);

			GetComponent<Renderer> ().material.SetFloat ("_WaveAmp" + waveNum, col.rigidbody.velocity.magnitude * mag);
		}
	}
}




















