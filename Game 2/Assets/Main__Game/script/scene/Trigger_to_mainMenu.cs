using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_to_mainMenu : MonoBehaviour {



    [SerializeField]
    private float duration=14f;

	private GameManager Gm;

    void Awake()
    {

        StartCoroutine(skipit());

		Gm = GetComponent<GameManager> ();

    }


    IEnumerator skipit()
    {

        yield return new WaitForSeconds(duration);


		Gm.Loadscene(1);

    }

	
	



}
