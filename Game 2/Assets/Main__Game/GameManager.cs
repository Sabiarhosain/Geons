using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public string Fading_anime = "";

    [SerializeField]
    private Animator anime;
	// Use this for initialization
	void Start () {


        
        Scene current_scene = SceneManager.GetActiveScene();


        int buildindex = current_scene.buildIndex;


        switch (buildindex)
        {

            case 1:

                anime.SetTrigger(Fading_anime);
                
                break;

        }


    }


   // IEnumerator Disolve() { }








    #region Scence Management 






    public void  Loadscene_withouyt (int index){

        StartCoroutine(Loadingscene(index));

    }

    public void Loadscene(int index)
    {

        StartCoroutine(Loadingscene(index));

    }
  
    IEnumerator Loadingscene (int index){


        AsyncOperation Operation = SceneManager.LoadSceneAsync(index);

        while(!Operation.isDone){


            Debug.Log(Operation.progress);

            yield return null;

        }

    }





    public void Reload_Scence()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    
    
  













    #endregion


    




    #region Pause_Menu


    public void  pause ()

    {
        Time.timeScale = 0f;
    }


    public void resume()
    {
        Time.timeScale = 1f;

    }





#endregion 







  








}
