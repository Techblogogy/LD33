using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour 
{
	public Animator batAnim;
	public float hitSpeed = 1.0f;
	public float hitAmmount;

	public float passedTime = 0;
	
	public int damage = 20;
	public float range = 50;

	private RaycastHit rayHit;

	public GameObject monsterVision;

	void Start () 
	{
		passedTime = hitSpeed;
	}
	
	void Update ()
	{
		passedTime += Time.deltaTime;

		if (Input.GetButton("Fire1") && passedTime >= hitSpeed)
		{
			//Debug.Log("Hit");

			// Deal Damage
			if (Physics.Raycast(this.transform.position, this.transform.forward, out rayHit, range))
			{
				if (rayHit.collider != null)
				{
					HumanAI hAI = rayHit.collider.gameObject.GetComponent<HumanAI>();
					if (hAI != null)
					{
						hAI.DealDamage(damage);
					}
				}
			}

			batAnim.SetTrigger("Attack");

			passedTime = 0;
		}

		if (Input.GetButton("Fire2") && !monsterVision.activeSelf)
		{
			monsterVision.SetActive(true); 
			this.GetComponent<Camera>().cullingMask ^= (1<<9);
		}
		else if (!Input.GetButton("Fire2") && monsterVision.activeSelf)
		{
			monsterVision.SetActive(false); 
			this.GetComponent<Camera>().cullingMask ^= (1<<9);
		}
	}
}
