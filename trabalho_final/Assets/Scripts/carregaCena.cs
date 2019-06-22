using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carregaCena : MonoBehaviour
{
    public void carregar(int valorCena) {
        SceneManager.LoadScene(valorCena);
    }

    public void sair() {
        Application.Quit();
    }

    public void playEfeito(AudioSource efeitoBotao) {
        efeitoBotao.Play();
    }
}
