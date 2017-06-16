using UnityEngine;
using System.Collections;

public class btPressed : MonoBehaviour {

    bool showChoice; // = false;
    public UILabel label;
    // Use this for initialization
    void Start () {
        showChoice = false;
    }
	
	// Update is called once per frame
	void Update () {

    }
    void OnGUI()
    {
        if (showChoice)
        {
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 200, 130), "Выбрать элемент");
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 20, 180, 30), "1"))
            {
                //   this.transform.GetChild(1).GetComponent<GUIText>().text = "1";
                label.text = "1";
                  showChoice = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 20, 180, 30), "&"))
            {
                //   this.transform.GetChild(1).GetComponent<GUIText>().text = "&";
                label.text = "&";
                showChoice = false;
            }
        }
    }

    void OnMouseDown()
    {
        showChoice = !showChoice;
    }  
}
