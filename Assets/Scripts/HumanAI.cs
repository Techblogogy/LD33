using UnityEngine;
using System.Collections.Generic;

public class HumanAI:MonoBehaviour
{
	private int Health = 100;

	public Transform target;
	private NavMeshAgent navAgent;

	void Start()
	{
		navAgent = GetComponent<NavMeshAgent>();
		navAgent.destination = target.position;
	}

	void Update()
	{
		
	}

	public void DealDamage(int hp)
	{
		Health -= hp;
		
		Debug.Log(Health);

		if (Health < 0)
		{
			Debug.Log("DEAD");
		}
	}
}
