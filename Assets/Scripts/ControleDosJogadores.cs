using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDosJogadores : MonoBehaviour
{
    public float velocidadeDoJogador;
    public bool jogador1;
    public float yMinimo;
    public float yMaximo;

    void Update()
    {
        float movimentoVertical = 0f;

        if (jogador1)
        {
            // Setas do teclado para o jogador 1
            if (Input.GetKey(KeyCode.W))
                movimentoVertical = 1f;
            else if (Input.GetKey(KeyCode.S))
                movimentoVertical = -1f;
        }
        else
        {
            // Teclas W e S para o jogador 2
            if (Input.GetKey(KeyCode.UpArrow))
                movimentoVertical = 1f;
            else if (Input.GetKey(KeyCode.DownArrow))
                movimentoVertical = -1f;
        }

        // Aplica movimento e limita posição vertical
        Vector2 novaPosicao = transform.position;
        novaPosicao.y += movimentoVertical * velocidadeDoJogador * Time.deltaTime;
        novaPosicao.y = Mathf.Clamp(novaPosicao.y, yMinimo, yMaximo);
        transform.position = novaPosicao;
    }
}
