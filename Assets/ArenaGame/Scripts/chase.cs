using UnityEngine;
using System.Collections;

public class chase : MonoBehaviour {

	public Transform player;
	public bool estaDentro = false;
	static Animator anim;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(estaDentro){
			Vector3 direction = player.position - this.transform.position;
			float angle = Vector3.Angle(direction,this.transform.forward);
			if(Vector3.Distance(player.position, this.transform.position) < 10 && angle < 30)
			{
				
				direction.y = 0;

				this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
											Quaternion.LookRotation(direction), 0.5f);

				if(direction.magnitude > 1)
				{
					this.transform.Translate(0,0,0.05f);
					anim.SetBool("isWalking",false);
					anim.enabled = false;
				}

			}
			else 
			{
				anim.SetBool("isWalking", true);
				anim.enabled = true;
			}
		} else {
			anim.SetBool("isWalking", true);
			anim.enabled = true;
		}

	}
	
	void OnTriggerStay(Collider col){
		if(col.gameObject.name.StartsWith("Character(Clone)")){
			player = col.transform;
			anim.SetBool("isWalking", true);
			estaDentro = true;
		}
	}
	
	void OnTriggerExit(Collider col){
		if(col.gameObject.name.StartsWith("Character(Clone)")){
			player = null;
			anim.SetBool("isWalking",false);
			estaDentro = false;
		}
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.name.StartsWith("Character(Clone)")){
			player = col.transform;
			anim.SetBool("isWalking", true);
			estaDentro = true;
		}
	}
	
}
