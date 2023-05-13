using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void GoToTitle()
    {
        SceneManager.LoadScene("TitleScene");
        GameManager.instance.score = 0;
    }

    public static void GoToGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public static void Quit()
    {

    }
}
