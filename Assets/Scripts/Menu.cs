using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public List<Button> buttons;

    private void Start()
    {
        if (buttons != null && buttons.Count > 0)
        {
            EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
        }
    }

    public void LoadScenes(string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void Quit()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }
}
