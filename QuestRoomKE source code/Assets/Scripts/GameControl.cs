using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

    public Camera cam1 = new Camera();
    public Camera cam2 = new Camera();


    // Use this for initialization
    void Start () {
        // cam1 = new Camera();
       //  cam2 = new Camera();
}
	
	// Update is called once per frame
	void Update () {

       
	}

    void NewGame()
    {
        Application.LoadLevel("game");
    }

    void AboutGame()
    {
        cam1.enabled = false;
        cam2.enabled = true;
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void BackToMenu()
    {
        cam1.enabled = true;
        cam2.enabled = false;
    }
}
