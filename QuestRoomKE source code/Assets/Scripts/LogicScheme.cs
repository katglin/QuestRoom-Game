using UnityEngine;
using System.Collections;

public class LogicScheme : MonoBehaviour {

    public GameObject wind;
    public UILabel l1;
    public UILabel l2;
    public UILabel l3;
    public UILabel l4;
    public static bool result = false;
    bool showRes; // = false;
    string resMess; // = "Что-то не подходит";
    // Use this for initialization
    void Start () {
        result = false;
        resMess = "Что-то не подходит";
        showRes = false;
        l1.text = "?";
        l2.text = "?";
        l3.text = "?";
        l4.text = "?";
    }
	/*
	// Update is called once per frame
	void Update () {
	
        if (showSheme)
        {
            showSheme = false;
            Cursor.visible = true;
            showShemeWind();
        }
	}
    */

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
        if (l1.text =="&" && l2.text== "1" && l3.text== "1" && l4.text== "&")
        {
            result = true;
            // resMess = "Все верно!";
            // showRes = true;
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
