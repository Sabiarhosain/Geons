using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swardcollision : MonoBehaviour {

    [SerializeField]
    private int hit_value;

    void OnTriggerEnter2D(Collider2D other ) {


        DamagableIteams hit =other.GetComponent<DamagableIteams>();

        if (hit != null)
        {

            hit.Damage(hit_value);

        }


    }

   


}
