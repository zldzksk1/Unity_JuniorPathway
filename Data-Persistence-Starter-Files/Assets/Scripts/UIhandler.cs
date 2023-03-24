using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIhandler : MonoBehaviour
{

    public TextMeshProUGUI nameInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
       // UpdateName();
        SceneManager.LoadScene(1);
    }

    public void UpdateName()
    {
        PlayerDataManger.Instance.playerName = nameInput.text;
    }
}
