using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public void OnQuit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Quit();
        }
    }

    
}
