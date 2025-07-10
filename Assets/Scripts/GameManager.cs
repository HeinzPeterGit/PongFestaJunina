using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class GameManager : MonoBehaviour
{
    public int pontuacaoDoJogador1;
    public int pontuacaoDoJogador2;
    public Text textDePontuacao;
    public AudioSource somDoGol;
    public Text TextGameOver;
    public static string vencedor;

    public Transform spawnJogador1;
    public Transform spawnJogador2;

    public PlayerInputManager playerInputManager;

    private int jogadoresSpawnados = 0;
    public BallController ballController; // arraste o objeto da bola no Inspector

    // Start is called before the first frame update
    void Start()
    {
        pontuacaoDoJogador1 = 0;
        pontuacaoDoJogador2 = 0;
        textDePontuacao.text = pontuacaoDoJogador1 + " X " + pontuacaoDoJogador2;
        Time.timeScale = 1; // Garante que o jogo começa em movimento (não pausado)
    }

    // Update is called once per frame
    void Update()
    {
        // Detectando se o jogador pressionou o botão de reiniciar no teclado (tecla "Enter")
        if (Input.GetKeyDown(KeyCode.Return)) // A tecla "Enter" é comum para reiniciar
        {
            ReiniciarPartida();
        }

        // Detectando se o jogador pressionou o botão de sair no teclado (tecla "Esc")
        if (Input.GetKeyDown(KeyCode.Escape)) // A tecla "Esc" é comum para sair
        {
            SairDoJogo();
        }
    }

    public void AumentarPontuacaoDoJogador1()
    {
        pontuacaoDoJogador1 += 1;
        AtualizarTextoDePontuacao();
    }

    public void AumentarPontuacaoDoJogador2()
    {
        pontuacaoDoJogador2 += 1;
        AtualizarTextoDePontuacao();
    }

    public void AtualizarTextoDePontuacao()
    {
        textDePontuacao.text = pontuacaoDoJogador1 + " X " + pontuacaoDoJogador2;
        somDoGol.Play();

        // Verificar se qualquer jogador atingiu 10 pontos
        if (pontuacaoDoJogador1 >= 10)
        {
            vencedor = "Jogador 1"; // Definir o vencedor
            textDePontuacao.text = $"{vencedor} Venceu!";
            SceneManager.LoadScene("Gamer Over");
        }
        else if (pontuacaoDoJogador2 >= 10)
        {
            vencedor = "Jogador 2"; // Definir o vencedor
            textDePontuacao.text = $"{vencedor} Venceu!";
            SceneManager.LoadScene("Gamer Over");
        }
    }

   

   

    private void ReiniciarPartida()
    {
        // Reinicia a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SairDoJogo()
    {
        Application.Quit();
        Debug.Log("Saiu do Jogo");
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        if (playerInput.playerIndex == 0 && spawnJogador1 != null)
        {
            playerInput.transform.position = spawnJogador1.position;
        }
        else if (playerInput.playerIndex == 1 && spawnJogador2 != null)
        {
            playerInput.transform.position = spawnJogador2.position;
        }

        jogadoresSpawnados++;

        if (jogadoresSpawnados == 2 && ballController != null)
        {
            ballController.IniciarMovimento();
        }
    }
}
