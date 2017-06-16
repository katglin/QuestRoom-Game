using UnityEngine;
using System.Collections;

public class btTestPressed : MonoBehaviour {


    bool showChoice; // = false;
    public UILabel label;
    // Use this for initialization
    void Start()
    {
        showChoice = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        if (showChoice)
        {
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 200, 170), "Выбрать ответ");
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 20, 180, 30), "А"))
            {
                //   this.transform.GetChild(1).GetComponent<GUIText>().text = "1";
                label.text = "A";
                showChoice = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 20, 180, 30), "В"))
            {
                //   this.transform.GetChild(1).GetComponent<GUIText>().text = "&";
                label.text = "B";
                showChoice = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 60, 180, 30), "С"))
            {
                //   this.transform.GetChild(1).GetComponent<GUIText>().text = "&";
                label.text = "C";
                showChoice = false;
            }
        }
    }

    void OnMouseDown()
    {
        showChoice = !showChoice;
    }
}
