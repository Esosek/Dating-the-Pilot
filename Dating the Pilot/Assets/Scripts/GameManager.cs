using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject plane;

    private void Awake()
    {
        instance = this;
    }

    public void GameWon()
    {
        Debug.Log("Game won!");
        // load thanks for playing scene

        Cursor.visible = true;

        LevelChanger.instance.FadeToLevel(2);
    }

    public void GameLost()
    {
        Debug.Log("Game lost!");

        LevelChanger.instance.FadeToLevel(1);
    }

    public void StartGameplay()
    {
        plane.SetActive(true);
    }
}
