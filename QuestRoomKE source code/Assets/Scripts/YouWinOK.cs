using UnityEngine;
using System.Collections;

public class YouWinOK : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ReturnToMenu()
    {
        Application.LoadLevel(0);
    }
}
