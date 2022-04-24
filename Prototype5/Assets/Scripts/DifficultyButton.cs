/*
 * Josh McGrew
 * Assignment 8 Prototype 5
 * difficulty button
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;

    private GameManager gameManager;

    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        button = GetComponent<Button>();

        button.onClick.AddListener(setDifficulty);
    }

    void setDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
