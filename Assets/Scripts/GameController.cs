using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController:MonoBehaviour
{
	public GameObject Player;
	public GameObject Human;

	public List<Transform> playerSpawn = new List<Transform>();
	public List<Transform> humanSpawn = new List<Transform>();

	void Start()
	{
		SpawnHuman();
		SpawnPlayer();
	}

	void Update()
	{
		
	}

	private void SpawnHuman()
	{
		int RandomPoint = Random.Range(0,humanSpawn.Count);
		Vector3 position = humanSpawn[RandomPoint].position;

		Debug.Log(Human.transform.position);
		Human.transform.position = position;

		Human.GetComponent<HumanAI>().StartCycle();

		Debug.Log(position);
	}

	private void SpawnPlayer()
	{
		int RandomPoint = Random.Range(0,playerSpawn.Count);
		Vector3 position = playerSpawn[RandomPoint].position;
		Quaternion rotation = playerSpawn[RandomPoint].rotation;

		Player.transform.position = position;
		Player.transform.rotation = rotation;

		Debug.Log(position);
	}

	public void WinGame(int chestLeft)
	{
		Debug.Log("You Won. Chests Left: "+chestLeft);
	}

	public void LooseGame(int chestLeft)
	{
		Debug.Log("You've Lost. Chests Left:"+chestLeft);
	}
}
