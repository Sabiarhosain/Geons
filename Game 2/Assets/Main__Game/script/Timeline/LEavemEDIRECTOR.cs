using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LEavemEDIRECTOR : MonoBehaviour
{

    public Animator PlayerAnimator;
    public RuntimeAnimatorController playeranime;
    private bool Fix = false;

    [SerializeField] private PlayableDirector Director;



 
    void OnEnable()
    {
        playeranime = PlayerAnimator.runtimeAnimatorController;

        PlayerAnimator.runtimeAnimatorController = null;
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Delay());

     
    
    }

    private IEnumerator Delay() {




        if (Director.state != PlayState.Playing && !Fix)
        {

            Fix = true;

            PlayerAnimator.runtimeAnimatorController = playeranime;

            yield return new WaitForSeconds(.5f);



        }


    }


}
