using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  enemy  : MonoBehaviour {
	
    [SerializeField] protected Animator anim;
	[SerializeField] protected Transform playerdetection;
	[SerializeField] protected float distance =5f;
	protected Transform Player;

	[SerializeField] protected float stopAI;

    [SerializeField]
    protected string anime_chase = "";

    [SerializeField]
    protected string anime_patrol = "";

    [SerializeField]
    protected string anime_hit = "";

    [SerializeField]
    protected string anime_Attack = "";

    [SerializeField]
    protected float enemy_attack_duration = 2f;

    [SerializeField]
    protected int Health;
    [SerializeField]
    protected string anime_is_dead="";

    protected CapsuleCollider2D Capsule;
    protected Rigidbody2D rb;
   [SerializeField] protected enemy enem;


   [SerializeField]
   protected GameObject Blood_efect;

   [SerializeField]
   protected Transform target;


	void Start ( ) {
		init();

	}//start


	public virtual void init () {

		anim = GetComponentInChildren<Animator> ();
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
        Capsule = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        enem = GetComponent<enemy>();
        
	}




	public virtual void Update () {


         float difference = Vector2.Distance(transform.position, Player.position);


		if (difference < distance) {
            anim.SetBool(anime_chase, true);
            anim.SetBool(anime_Attack, false);


		} else {

            anim.SetBool(anime_chase, false);
            anim.SetBool(anime_Attack, false);

		}


        
		if (difference < stopAI) {

			transform.position = this.transform.position;
            anim.SetBool(anime_chase, false);



            anim.SetBool(anime_Attack, true);
        
        }


        Fliptoplayer(difference); //dont removeit it will flip the character to the player
	}



  

	 void Fliptoplayer(float difference){


		float Distance = Vector3.Distance (Player.transform.localPosition, transform.position);

		Vector3 Diraction = Player.transform.localPosition - transform.localPosition;


		if (Diraction.x < 0 && difference <distance) {

			transform.eulerAngles = new Vector3 (0f,180f,0f);
		}else if(Diraction.x > 0){
			transform.eulerAngles = new Vector3 (0f,0f,0f);
		}
    
     }









     public IEnumerator stop_for_second()
     {

         anim.SetBool(anime_Attack, false);

         yield return new WaitForSeconds(1f);


     }




   

}//class
