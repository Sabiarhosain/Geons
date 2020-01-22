using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDistroyer : MonoBehaviour {




    public float Time;




    void Awake()
    {

        Destroy(gameObject, Time);
    }





}
