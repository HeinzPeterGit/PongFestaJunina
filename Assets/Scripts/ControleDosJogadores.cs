using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ControleDosJogadores : MonoBehaviour
{
    public float velocidadeDoJogador;
    public bool jogador1;
    public float yMinimo;
    public float yMaximo;

    private float movimentoVertical;

    public void OnMove(InputAction.CallbackContext context)
    {
        movimentoVertical = context.ReadValue<Vector2>().y;
    }

    void Update()
    {
        Vector2 novaPosicao = transform.position;
        novaPosicao.y += movimentoVertical * velocidadeDoJogador * Time.deltaTime;
        novaPosicao.y = Mathf.Clamp(novaPosicao.y, yMinimo, yMaximo);
        transform.position = novaPosicao;
    }
    public void OnMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ReturnMenu();
        }
    }

    void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
