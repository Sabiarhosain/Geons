using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
public class Player : MonoBehaviour ,DamagableIteams
{


    #region variables

    [SerializeField]
    private int Health = 20;

    [SerializeField]private float speed =40f;
	[SerializeField]private float jumpspeed =40f;
	[SerializeField]private LayerMask WhatIsground;
	[SerializeField]float HOrizontal;
	[SerializeField]float Vertical;
	[SerializeField]private Rigidbody2D rb;
	[SerializeField]private Animator anime;
	[SerializeField] bool onground;
	//[SerializeField]float resettime=1f;
	private bool isfacingright=true;
	//float minx = -32.92144f;

    [SerializeField]private Slider Healthbar;

    [SerializeField]private CapsuleCollider2D box2d;
    [SerializeField] private Player player;


    [SerializeField] private Button[] player_attacks;

    [SerializeField] private GameObject Effect_blood;
    
    [SerializeField] private GameObject particle_target;



    [SerializeField]    private GameObject Retrypanel;


    #endregion

	





    private void Start () {
		onground = true;
		rb = GetComponent<Rigidbody2D> ();
		anime = GetComponent<Animator> ();
        box2d = GetComponent<CapsuleCollider2D>();

        player = GetComponent<Player>();


	
	
	}//Start
	






	private void FixedUpdate () {
       

		Movemnt ();


		RaycastHit2D racast = Physics2D.Raycast (transform.position,Vector2.down,.3f,WhatIsground);
		Debug.DrawRay (transform.position, Vector2.down , Color.green);

		if (racast.collider != null) {
		
			onground = true;
			anime.SetBool ("canjump",false);
		}

		Vertical = CrossPlatformInputManager.GetAxis ("Vertical");

			if(Vertical >=1 && onground ==true)
			jump ();


           


	}//fixedupdate



    #region player movement and jump


    void Movemnt (){
	
		HOrizontal = CrossPlatformInputManager.GetAxis ("Horizontal");
        rb.velocity = new Vector2(HOrizontal * speed * Time.fixedDeltaTime, rb.velocity.y);
		
        anime.SetFloat ("run", Mathf.Abs (HOrizontal));
		//----------------------xxxxxxxxxx--------------------------//
		if (isfacingright == true && HOrizontal < 0) {
			Flip (); 
		} else if (isfacingright == false && HOrizontal > 0) {
			Flip ();
		}

	}//Movement



	void Flip () {

		isfacingright = !isfacingright;

		Vector3 Scaler = transform.localScale;

		Scaler.x *= -1f;
		transform.localScale = Scaler;

	}//Flip

    
	void jump(){
	
		anime.SetBool ("canjump", true);
		rb.velocity = new Vector2 (rb.velocity.x , jumpspeed*jumpspeed);  

		onground = false;
        

		
	}

    #endregion    // //---------------


  



    public void Damage(int damagenum)
    {

        anime.SetTrigger("Hit");

        Health -= damagenum;
        Healthbar.value = Health;

       Instantiate(Effect_blood,particle_target.transform.position,Quaternion.identity);



      // Effect_blood.SetActive(true);
      // StartCoroutine(reseteffect());


        if (Health <=0)
        {
            Hitanime_dead();
            box2d.enabled = false;
            rb.gravityScale = 0f;
            player.enabled = false;
          
            
            player_attacks[0].interactable =false;
            player_attacks[1].interactable = false;
            player_attacks[2].interactable = false;

        }
       
    }


   // IEnumerator reseteffect()
  //  {
    //    yield return new WaitForSeconds(1f);

   //     Effect_blood.SetActive(false);
//

 //   }






	#region attack
	public void Attack1 () {

		anime.SetTrigger ("attack1");
	}
	public void Attack2 () {

		anime.SetTrigger ("attack2");

	}
	public void exclaim () {

		anime.SetTrigger ("exclaimed");

	}


	#endregion





    public void Hitanime_dead()
    {

        anime.SetTrigger("isdead");


    }



    public void retrypanel()
    {

        Retrypanel.SetActive(true);
        Time.timeScale = 0f;
    }













 
}//Class

