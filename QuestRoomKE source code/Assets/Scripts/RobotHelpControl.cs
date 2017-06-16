using UnityEngine;
using System.Collections;

public class RobotHelpControl : MonoBehaviour {

    //   public const int hintCount = 1;
    //    int curHint = 0; // number of next hint in array
    //   int hintLeft = hintCount;
    bool haveHint = true;
    string[] hints = { "В комнате есть платформа, открывающая скрытый в стене сейф",
                       "Переведите 5 чисел в десятичную систему из двоичной" };

    bool inTrigger = false;
    bool showHints = false; // open dialog - 'F' pressed
    bool showHintText = false; // hint was chosen
    int number;

	void Start () {
        haveHint = true;
        inTrigger = false;
        showHints = false; 
        showHintText = false; 
    }
	
	void Update ()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.F))
        {
            Cursor.visible = true;
            showHints = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = false;
        }
    }

    void OnGUI()
    {
        GUI.color = Color.yellow;
        if (inTrigger)
        {
          //  Debug.Log("F");
            GUILayout.BeginArea(new Rect((Screen.width) / 2, 24, 200, 200));
            GUILayout.Label("Press 'F' to use object");
            GUILayout.EndArea();
        }
        if (showHints && haveHint)
        {
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 400, 160), "Вам доступна 1 подсказка, что вы выберете?");
            if (GUI.Button(new Rect(Screen.width / 2 + 50, Screen.height / 2 - 20, 180, 30), "Починить ПК"))
            {
                showHints = false;
                number = 0;
                showHintText = true;
                haveHint = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 50, Screen.height / 2 + 20, 180, 30), "Пароль к ПК"))
            {
                showHints = false;
                number = 1;
                showHintText = true;
                haveHint = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 50, Screen.height / 2 + 60, 180, 30), "Отмена"))
            {
                showHints = false;
                Cursor.visible = false;
            }
        }
        else if (showHints && !haveHint)
        {
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 450, 70),
                       "К сожалению, вы уже использовали свою подсказку");
            if (GUI.Button(new Rect(Screen.width / 2 + 160, Screen.height / 2 - 20, 80, 30), "ОК"))
            {
                showHints = false;
                Cursor.visible = false;
            }
        }
        if (showHintText)
        {
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 500, 70),
                       hints[number]);
            if (GUI.Button(new Rect(Screen.width / 2 + 160, Screen.height / 2 - 20, 80, 30), "ОК"))
            {
                showHintText = false;
                Cursor.visible = false;
            }
        }
    }
}
