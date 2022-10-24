using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficaultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficaulty=1;
    private GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
        button=GetComponent<Button>();
        button.onClick.AddListener(SetDifficaulty);
        titleScreen=GameObject.Find("TitleScreen");
    }

    void SetDifficaulty()
    {
       // Debug.Log(gameObject.name+" was Clicked");
        gameManager.StartGame(difficaulty);
        titleScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
