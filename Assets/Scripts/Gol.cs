using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gol : MonoBehaviour
{
    public bool golDoJogador1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (golDoJogador1 == true)
        {
            FindAnyObjectByType<GameManager>().AumentarPontuacaoDoJogador2();
            other.gameObject.transform.position = Vector2.zero;
        }
        else
        {
            FindAnyObjectByType<GameManager>().AumentarPontuacaoDoJogador1();
            other.gameObject.transform.position = Vector2.zero;
        }
    }
}
