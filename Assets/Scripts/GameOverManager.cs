using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text textVencedor;

    void Start()
    {
        if (textVencedor != null)
        {
            textVencedor.text = "Vencedor é o " + GameManager.vencedor;
        }
    }

    void Update()
    {
        // Botão Start (Joystick Button 7) para reiniciar o jogo
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            ReiniciarJogo();
        }

        // Botão X (Joystick Button 2) para sair/voltar ao menu
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            VoltarAoMenu();
        }

        // Opcional: também permitir Enter ou teclado
        if (Input.GetButtonDown("Submit"))
        {
            ReiniciarJogo();
        }
        if (Input.GetButtonDown("Cancel"))
        {
            VoltarAoMenu();
        }
    }

    void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void VoltarAoMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
