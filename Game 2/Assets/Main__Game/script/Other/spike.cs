using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spike : MonoBehaviour  {


    private Player player;

    [SerializeField] Slider healthbar;
    [SerializeField]
    Button[] playerbts;
    
    void OnCollisionEnter2D (Collision2D col){

        if (col.collider.CompareTag("Player"))
        {
           player = FindObjectOfType<Player>();
           player.Hitanime_dead();
           player.enabled = false;
           healthbar.value = 0;

                playerbts[0].interactable = false;
                playerbts[1].interactable =false;
                playerbts[2].interactable =false;
        }


    }
}
