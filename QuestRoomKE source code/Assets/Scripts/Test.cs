using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    public GameObject wind;
    public UILabel l1;
    public UILabel l2;
    public UILabel l3;
    public static bool TestResult = false;
    bool showRes; // = false;
    string resMess; // = "Что-то не подходит";
    // Use this for initialization
    void Start()
    {
        TestResult = false;
        resMess = "Попробуйте еще раз";
        showRes = false;
        l1.text = "?";
        l2.text = "?";
        l3.text = "?";
    }

    void OnGUI()
    {
        if (showRes)
        {
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 300, 70),
                       resMess);
            if (GUI.Button(new Rect(Screen.width / 2 + 60, Screen.height / 2 - 20, 80, 30), "ОК"))
            {
                showRes = false;
            }
        }
    }

    void OkPressed()
    {
        if (l1.text == "C" && l2.text == "A" && l3.text == "B")
        {
            TestResult = true;
             resMess = "Все верно!";
             showRes = true;
        }
        else
        {
            showRes = true;
        }
    }
    void CancelPressed()
    {
        //  cam1.enabled = true;
        //  cam2.enabled = false;
        wind.SetActive(false);
        Cursor.visible = false;
    }
}
