using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jaint : enemy,DamagableIteams {




    public void Damage(int damagenum)
    {

        anim.SetTrigger(anime_hit);
        Health-=damagenum;
        Instantiate(Blood_efect, target.transform.position, Quaternion.identity);

        if (Health < 1)
        {

            anim.SetTrigger(anime_is_dead);
            Capsule.enabled = false;
            rb.gravityScale = 0f;
            enem.enabled = false;

        }
    
    }

  
}