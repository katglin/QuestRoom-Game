using UnityEngine;
using System.Collections;

public class UseObjects : MonoBehaviour {

    private bool showTakeDialog; // = false; // 'E' pressed in trigger
    private bool showUseDialog; // = false; // 'F' pressed in trigger
    public GameObject CurPlayer; // pointer to player
    bool inTrig; // = false; // player is in trigger
    bool takeOb; // = false;  // button TakeMenu'OK' was pressed   public static
    public static bool isBusy; // = false;  // hand of fpc are busy
    bool keepOb; // = false; // this object is taken
    public static GameObject takenObject; // thing in your hands
    string text; // message in the bottom of screen, help-notes
    public float timeDelayText = 2; // time to show help-notes on screen
    bool PCisBroken; // = true;
    bool notHelp; // = false; // you use possible hints
    bool useBuben; // = false; // you are holding buben
    static bool PCisDone; // = false;  // ? we already have var 'PCisBroken'
    static bool PCisLocked; // = true; 
    public string Password = "42170";
    bool showLoseDialog; // = false;
    string pass;
    string GuessPass; // = "Компьютер заблокирован";
 //   public bool Win; // = false;
    bool showPassGuessedDialog;
    public GameObject wind; // logic scheme
    public GameObject windTest; // test
    public GameObject Door;
    public bool openDoor;
    bool optionOpenDoor;
  //  bool showTest;

    void Start () {

    showTakeDialog = false; 
    showUseDialog = false; 
    inTrig = false;
    takeOb = false; 
    isBusy = false; 
    keepOb = false;                 
    PCisBroken = true;
    notHelp = false;
    useBuben = false;
    PCisDone = false;
    PCisLocked = true;
 //   Password = "12345";
    showLoseDialog = false;
    pass = "";
    GuessPass = "Компьютер заблокирован";
    showPassGuessedDialog = false;
    openDoor = false;
    LogicScheme.result = false;
    Test.TestResult = false;
    optionOpenDoor = false;
  //  showTest = false; 

    Cursor.visible = false;
    text = "Игра началась";
    Invoke("clearText", timeDelayText);
    }
	
	void Update () {

        // You lose - time end
        if (Timer.timeEnd)
        {
            Cursor.visible = true;
            showLoseDialog = true;
        }
        // press E
        if (inTrig && Input.GetKeyDown(KeyCode.E) && !keepOb && gameObject.tag != "Компьютер")
        {
            Cursor.visible = true;
            showTakeDialog = true;
        }
        if (keepOb) // not to fall, take up
        {
            this.gameObject.transform.parent.gameObject.transform.position =
                       new Vector3(this.gameObject.transform.parent.gameObject.transform.position.x,
                        CurPlayer.transform.position.y,
                        this.gameObject.transform.parent.gameObject.transform.position.z);
        }
        // - take the object
        if (inTrig && takeOb)
        {
            takenObject = gameObject;
            text = "Вы взяли предмет: " + takenObject.tag;
            Invoke("clearText", timeDelayText);
            takeOb = false;
            keepOb = true;
            isBusy = true; 
            this.gameObject.transform.parent.gameObject.transform.position =
                        new Vector3(this.gameObject.transform.parent.gameObject.transform.position.x,
                         CurPlayer.transform.position.y,
                         this.gameObject.transform.parent.gameObject.transform.position.z);
            this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().drag = 100;//
            this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = false; //for shelves
            this.gameObject.transform.parent.gameObject.transform.SetParent(CurPlayer.transform);
        }
        // throw the object
        if (keepOb && Input.GetKeyDown(KeyCode.R))
        {
            try
            {
                text = "Вы бросили предмет: " + takenObject.tag;    
            }
            catch {
                text = "Вы уронили предмет";
            }
            this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().drag = 0;//                                                                                            //      this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = false;//
            Invoke("clearText", timeDelayText);
            takenObject = null;
            keepOb = false;
            isBusy = false;
            this.gameObject.transform.parent.gameObject.transform.SetParent(CurPlayer.transform.parent);
            this.gameObject.transform.parent.gameObject.transform.rotation = CurPlayer.transform.rotation;
            this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().velocity =
                CurPlayer.transform.TransformDirection(new Vector3(0, 0, 8));
        }
        if (inTrig && Input.GetKeyDown(KeyCode.F) && gameObject.tag == "Компьютер")
        {
            Cursor.visible = true;
            showUseDialog = true;
        }
        if (LogicScheme.result == true && PCisBroken)
        {
            PCisDone = true;
            PCisBroken = false;
        }
        if (Test.TestResult == true && !openDoor && this.tag == "Компьютер")
        {
            openDoor = true;
            optionOpenDoor = false;
            text = "Дверь сейчас откроется!";
            Invoke("clearText", 5);
            Invoke("OpenDoor", 7);
        }
    }

   
    void OnTriggerEnter(Collider player)
    {

        if (player.tag == "Player")
        {
            inTrig = true;
            CurPlayer = player.gameObject;
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
            inTrig = false;
    }

    void clearText()
    {
        text = "";
    }
    
    void OnGUI()
    {
        GUI.color = Color.yellow;
        GUI.Label(new Rect(40, Screen.height-40, 600, 40), text);
        #region showUseDialog 
        if (showUseDialog)
        {
            if (PCisBroken && (!takenObject || (takenObject.tag != "Бубен" && takenObject.tag != "Отвертка")))
            {
                GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 200, 130), "Компьютер сломан");
                if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 20, 180, 30), "Перезагрузить"))
                {
                    showUseDialog = false;
                    notHelp = true;
                }
                if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 20, 180, 30), "Отмена"))
                {
                    showUseDialog = false;
                    Cursor.visible = false;
                }
            }
            else if (PCisBroken && takenObject.tag == "Бубен")
            {
                GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 200, 160), "Компьютер сломан");
                if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 20, 180, 30), "Перезагрузить"))
                {
                    showUseDialog = false;
                    notHelp = true;
                }
                if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 20, 180, 30), "Танцы с бубном"))
                {
                    showUseDialog = false;
                    useBuben = true;
                }
                if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 60, 180, 30), "Отмена"))
                {
                    showUseDialog = false;
                    Cursor.visible = false;
                }
            }
            else if (PCisBroken && takenObject.tag == "Отвертка")
            {
                GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 200, 160), "Компьютер сломан");
                if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 20, 180, 30), "Перезагрузить"))
                {
                    showUseDialog = false;
                    notHelp = true;
                }
                if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 20, 180, 30), "Разобрать"))
                {
                    if (this.tag == "Компьютер")
                    {
                        showUseDialog = false;
                        wind.SetActive(true);
                        Cursor.visible = true;
                    }
                    /*
                    if (LogicScheme.result==true)
                     {
                         showUseDialog = false;  //!!
                         PCisDone = true;
                     }
                     */
                }
                if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 60, 180, 30), "Отмена"))
                {
                    showUseDialog = false;
                    Cursor.visible = false;
                }
            }
            else if (!PCisBroken && PCisLocked)
            {
                GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 200, 200), GuessPass);
                GUI.Label(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 20, 180, 30), "Пароль:");
                pass = GUI.TextField(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 20, 150, 30), pass,10);
                if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 60, 180, 30), "Ввести"))
                {
                    
                    if (pass == Password)
                    {
                        showUseDialog = false;
                        PCisLocked = false;
                        showPassGuessedDialog = true;
                    }
                    else
                    {
                        GuessPass = "Указан не правильный пароль";
                    }
                }
                if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 100, 180, 30), "Отмена"))
                {
                    showUseDialog = false;
                    Cursor.visible = false;
                }
            }
            else if (optionOpenDoor)
            {
                GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 300, 70),
                           "Открыть дверь?");
                if (GUI.Button(new Rect(Screen.width / 2 + 60, Screen.height / 2 - 20, 80, 30), "ОК"))
                {
                 //   optionOpenDoor = false;
                    //    openDoor = true;  //
                    //showTest = true;
                    if (this.tag == "Компьютер")
                    {
                        showUseDialog = false;
                    //    optionOpenDoor = false;
                        windTest.SetActive(true);
                        Cursor.visible = true;
                    }
                }
            }
        }
        #endregion
        #region passGuessedDialog
        if (showPassGuessedDialog)
        {
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 300, 70),
                       "Пароль подошел!");
            if (GUI.Button(new Rect(Screen.width / 2 + 60, Screen.height / 2 - 20, 80, 30), "ОК"))
            {
                PCisLocked = false; //
                showPassGuessedDialog = false;
                optionOpenDoor = true;
         //       openDoor = true; // not here
            }
        }
        
        #endregion
        #region ReloadNotHelp
        if (notHelp)
        {
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 300, 70),
                       "Не помогло, может, стоит его починить?");
            if (GUI.Button(new Rect(Screen.width / 2+60, Screen.height / 2 - 20, 80, 30), "ОК"))
            {
                showUseDialog = false;
                notHelp = false;
                Cursor.visible = false;
            }
        }
        #endregion
        #region useBuben
        if (useBuben)
        {
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 300, 70),
                       "Кажется, тут где-то есть отвертка");
            if (GUI.Button(new Rect(Screen.width / 2 + 60, Screen.height / 2 - 20, 80, 30), "ОК"))
            {
                showUseDialog = false;
                useBuben = false;
                Cursor.visible = false;
            }
        }
        #endregion
        #region PCwasDoneUra
        if (PCisDone && gameObject.tag=="Компьютер")
        {
            Cursor.visible = true;
            gameObject.transform.parent.GetComponent<ParticleSystem>().enableEmission = false;
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 300, 70),
                       "Все верно!");
            if (GUI.Button(new Rect(Screen.width / 2 + 60, Screen.height / 2 - 20, 80, 30), "ОК"))
            {
                showUseDialog = false;
                PCisDone = false; // need this to close dialog
           //     PCisBroken = false;
             //   Cursor.visible = false;
            }
        }
        #endregion
        #region showTakeDialog
        if (showTakeDialog && !isBusy)
        {
     //       Cursor.visible = true;
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 100), "Взять предмет '"+gameObject.tag +"'?");

            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), "Да"))
            {
                takeOb = true;
                showTakeDialog = false;
                Cursor.visible = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), "Нет"))
            {
                showTakeDialog = false;
                Cursor.visible = false;
            }
            
        }
        #endregion
        #region NotTakeisBusy
        else if (showTakeDialog && isBusy)
        {
            text = "У вас заняты руки, вы не можете взять это";
            Invoke("clearText", timeDelayText);
            Cursor.visible = false;
        }
        #endregion
        #region PressSmthTo
        if (inTrig && !keepOb && gameObject.tag != "Компьютер")
        {
            GUILayout.BeginArea(new Rect((Screen.width) / 2, 0, 200, 200));
            GUILayout.Label("Press 'E' to take object");
            GUILayout.EndArea();
        }
        if (keepOb)
        {
            GUILayout.BeginArea(new Rect((Screen.width) / 2, 12, 200, 200));
            GUILayout.Label("Press 'R' to throw object");
            GUILayout.EndArea();
        }
        if (inTrig && !keepOb && gameObject.tag == "Компьютер")
        {
            GUILayout.BeginArea(new Rect((Screen.width) / 2, 24, 200, 200));
            GUILayout.Label("Press 'F' to use object");
            GUILayout.EndArea();
        }
        #endregion
        #region showLoseDialog
        if (showLoseDialog)
        { 
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 140), "К сожалению, время вышло");

            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), "Начать заново"))
            { // Продолжить
              //   Cursor.visible = false;
              //   showLoseDialog = false;
                Application.LoadLevel(1);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), "Закончить игру"))
            { // Главное меню 
            //    Application.UnloadLevel(1);
                Application.LoadLevel(0);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2, 180, 30), "Выйти из игры"))
            { // Выход из игры
                Application.Quit();
            }
        }
        #endregion
    }

    void OpenDoor()
    { 
        Door.GetComponent<Animation>().Play("DoorOpen");
    }
}
