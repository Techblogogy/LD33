using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanAI:MonoBehaviour
{
	private int Health = 100;

	public List<Vector3> positions = new List<Vector3>();

	public Transform target;
	private NavMeshAgent navAgent;
	private Animator anim;

	public float walkSpeed = 2;
	public float walkSpeedTime = 1.0f;

	public float runSpeed = 10; 
	public float runSpeedTime = 2.0f;

	public float coolDownTime = 5.0f;

	private bool speadUp = false;
	private float speedTimer = 0.0f;

	private float posTimer = 0.0f;
	public float posTime = 2.0f;

	void Start()
	{
		navAgent = GetComponent<NavMeshAgent>();
		navAgent.destination = target.position;

		anim = GetComponent<Animator>();
	}

	void Update()
	{
		if (speadUp)
		{
			speedTimer += Time.deltaTime;
			if (speedTimer >= coolDownTime)
			{
				SlowDown();
			}
		}

		// Add Human Position To List Every 2 Seconds
	}

	public void DealDamage(int hp)
	{
		Health -= hp;

		SpeedUp();
		
		Debug.Log(Health);

		if (Health <= 0)
		{
			Debug.Log("DEAD");
		}
	}

	private void SpeedUp()
	{
		anim.SetFloat("Speed", runSpeedTime);
		navAgent.speed = runSpeed;

		speadUp = true;
		speedTimer = 0.0f;
	}

	private void SlowDown()
	{
		anim.SetFloat("Speed", walkSpeedTime);
		navAgent.speed = walkSpeed;

		speadUp = false;
	}
}
