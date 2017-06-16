using UnityEngine;
using System.Collections;

public class TriggerWin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        Cursor.visible = true;
        Application.LoadLevel(2);
    }
}
