using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayButton : MonoBehaviour

{
    public void StartGame()
    {
        // Aqui você pode adicionar qualquer lógica para iniciar o jogo
        // Por exemplo, carregar uma nova cena
        SceneManager.LoadScene("Sample Scene");
    }
}

// Importe a namespace para gerenciar cenas