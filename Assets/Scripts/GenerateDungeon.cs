using UnityEngine;
using System.Collections.Generic;

public class GenerateDungeon:MonoBehaviour
{
	public Transform dungeonBlock;
	public Transform dungeonBend;
	public float step = 3.0f;
	public int maxLength = 5;
	
	private Vector3 lastPos = Vector3.zero;
	private Vector3 direction = Vector3.forward;

	private Quaternion rotation = Quaternion.identity;
	private float blockRotation = 90;

	void Start()
	{
		for (int i=0; i<10; i++)
		{
			int length = Random.Range(1,maxLength);

			// Log Transform Position
			// Debug.Log(length);
			
			for (int d=0; d<length; d++)
			{
				// Put Dungeon Block Into World
				lastPos += direction * step;
				rotation.eulerAngles = new Vector3(270,blockRotation,0);
				Instantiate(dungeonBlock, lastPos, rotation);
			}
			
			
			//Change Rotation
			int rot = Random.Range(0,2);
			Debug.Log(rot);

			lastPos += direction*step;
			if (rot == 0)
			{
				rotation.eulerAngles = new Vector3(270,0,0);
				Instantiate(dungeonBend, lastPos, rotation);

				direction = Vector3.forward;
			}
			else 
			{
				rotation.eulerAngles = new Vector3(270,90,0);
				Instantiate(dungeonBend, lastPos, rotation);

				direction = Vector3.right;
			}

		}

	}

	void Update()
	{
		
	}
}
