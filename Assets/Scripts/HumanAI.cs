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

	public Transform footStep;

	public List<GameObject> chestList = new List<GameObject>();
	private ChestCTR chestAnm;

	public GameController gameCtr;

	void Start()
	{

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
		posTimer += Time.deltaTime;
		if (posTimer >= posTime)
		{
			Vector3 rot = this.transform.eulerAngles;
			
			Instantiate(footStep, new Vector3(this.transform.position.x, 0.001f, this.transform.position.z), Quaternion.Euler(90.0f, rot.y, rot.z));
			posTimer = 0;
		}

		if (navAgent.remainingDistance <= 0.2)
		{
			chestAnm.OpenChest();
			NextPoint();
		}
	}

	public void DealDamage(int hp)
	{
		Health -= hp;

		SpeedUp();
		
		Debug.Log(Health);

		if (Health <= 0)
		{
			gameCtr.WinGame(chestList.Count);
			Debug.Log("DEAD");
		}
	}

	private void SpeedUp()
	{
		anim.SetBool("Run", true);
		navAgent.speed = runSpeed;

		speadUp = true;
		speedTimer = 0.0f;
	}

	private void SlowDown()
	{
		anim.SetBool("Run", false);
		navAgent.speed = walkSpeed;

		speadUp = false;
	}

	public void StartCycle()
	{
		navAgent = GetComponent<NavMeshAgent>();
		//navAgent.destination = target.position;

		NextPoint();
	}

	private void NextPoint()
	{
		if (chestList.Count > 0)
		{
			int chestP = Random.Range(0,chestList.Count);
			chestAnm = chestList[chestP].GetComponent<ChestCTR>();

			navAgent.destination = chestList[chestP].transform.position;

			chestList.RemoveAt(chestP);
		}
		else
		{
			gameCtr.LooseGame(0);
		}
	}
}
