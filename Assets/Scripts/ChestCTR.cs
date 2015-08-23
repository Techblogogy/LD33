using UnityEngine;
using System.Collections.Generic;

public class ChestCTR:MonoBehaviour
{
	public GameObject chest;

	private Animator anim;

	void Start()
	{
		anim = chest.GetComponent<Animator>();
	}

	public void OpenChest()
	{
		anim.SetTrigger("Open");
	}
}
