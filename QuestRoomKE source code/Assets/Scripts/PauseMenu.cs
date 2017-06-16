/// <summary>
/// Pause.
/// Вешается на любой игровой объект
/// Вызывает меню с настройками и останавливает игру
/// </summary>
using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{

    // Игровая пауза
    private bool _paused = false;
    // Окна меню
    private int _window = 100;

    // Для вывода значений на экран
    private string StringWidth;
    private string StringHeight;

    public GameObject help;
 //   public Camera cam; // block camera

    void Start()
    {
        _paused = false;
        _window = 100;
    }

    // Update выполняется на каждый кадр 
    void Update()
    {

        // Ставим игру на паузу
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!_paused)
            {
                Cursor.visible = true;
                Time.timeScale = 0;
                _paused = true;
                _window = 0;
            }
            else {
                Cursor.visible = false;
                Time.timeScale = 1;
                _paused = false;
                _window = 100;
            }
        }
    }

    void OnGUI()
    {

        if (_window == 0)
        { // Главное меню активировано при _window = 0 
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 180), "Меню");

            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), "Продолжить"))
            { // Продолжить
                Cursor.visible = false;
                Time.timeScale = 1;
                _paused = false;
                _window = 100;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), "Помощь"))
            { // help
                _window = 1; // активируем окно "help" 
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), "Закончить игру"))
            { // Главное меню 
                Time.timeScale = 1;
                _paused = false;
                _window = 100;
                Application.LoadLevel(0);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "Выйти из игры"))
            { // Выход из игры
                Application.Quit();
            }
        }

        // help
        if (_window == 1)
        {
            help.SetActive(true);
       //     _paused = false;
        //    _window = 100;
        }
    }

    public void closeHelp()
    {
        Cursor.visible = false;
        help.SetActive(false);
        Time.timeScale = 1;
        _paused = false;
        _window = 100;
    }
}