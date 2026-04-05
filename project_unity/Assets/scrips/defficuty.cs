using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class defficuty : MonoBehaviour
{
    Button button;
    GameManager gameManager;
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = FindAnyObjectByType<GameManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        gameManager.StartNewGame(difficulty);
    }
}
