using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HDGuiManager : MonoBehaviour {

    [SerializeField]
    private Slider power_lvl;


    float value;




	void Awake () {
        power_lvl.value = value;
	
    
    }



	
	void Update () {
		
	
    
    }


    IEnumerator fill_power()
    {

        yield return new WaitForSeconds(2f);

        value += .3f;

    }

}
