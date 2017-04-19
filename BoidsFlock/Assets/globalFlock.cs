using UnityEngine;
using System.Collections;

public class globalFlock : MonoBehaviour {
	public GameObject fishPrefab;
	public GameObject[] goalPrefab;
	int cg = 0; 
	bool pathfollow;
	public static int tankSize = 5;
	static int numFish = 50;
	public static GameObject[] allFish = new GameObject[numFish];
	public static Vector3 goalPos = Vector3.zero;
	public float nd;
	GameObject[] fishArray;
	// Use this for initialization
	void Start () 
	{
		RenderSettings.fogColor = Camera.main.backgroundColor;
		RenderSettings.fogDensity = 0.020F;

		RenderSettings.fog = true;

		for(int i = 0; i < numFish; i++)
		{
			Vector3 pos = new Vector3(Random.Range(-tankSize,tankSize),
				Random.Range(-tankSize,tankSize),
				Random.Range(-tankSize,tankSize));
			allFish[i] = (GameObject) Instantiate(fishPrefab, pos, Quaternion.identity);
		}
		nd = 5.0f;
		fishArray = GameObject.FindGameObjectsWithTag ("fish");
		//Debug.Log (fishArray.Length);
	}

	// Update is called once per frame
	void Update () 
	{
		
		if(Random.Range(0,10000) < 50)
		{
			if (pathfollow == false) {
				goalPos = new Vector3 (Random.Range (-tankSize, tankSize),
					Random.Range (-tankSize, tankSize),
					Random.Range (-tankSize, tankSize));
			} else 
			{
				goalPos = goalPrefab [cg].transform.position;
				cg++;
				if(cg >= goalPrefab.Length)
				{
					cg = 0;
				}

			}
		}
		foreach (GameObject fish in fishArray) {
			fish.GetComponent<flock> ().neighbourDistance = nd;
		}

	}
	public void flockSeparation(float dist){
		nd = dist;
	}
	public void flockPath(bool fp){
		pathfollow = fp;
	}
	public void resetScene(){
		Application.LoadLevel (Application.loadedLevel);
	}
}
