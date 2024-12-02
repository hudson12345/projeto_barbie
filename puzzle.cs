using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleSequence : MonoBehaviour
{
    public int[] correctSequence = { 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12 }; // Sequência correta
    public string nextSceneName; // Nome da próxima cena a ser carregada

    private int currentStep = 0; // Passo atual do jogador
    public AudioClip correctSound; // Som de acerto
    public AudioClip wrongSound; // Som de erro

    // Função chamada quando o jogador entra no colisor
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu é um colisor válido
        if (other.CompareTag("Colisor"))
        {
            int colisorValue = other.GetComponent<ColisorValue>().value;

            // Cria um AudioSource temporário para tocar o som
            AudioSource tempAudioSource = gameObject.AddComponent<AudioSource>();

            if (colisorValue == correctSequence[currentStep])
            {
                // Jogador acertou o passo atual
                currentStep++;
                tempAudioSource.PlayOneShot(correctSound); // Toca o som de acerto

                // Verifica se a sequência está completa
                if (currentStep == correctSequence.Length)
                {
                    SceneManager.LoadScene(nextSceneName); // Troca de cena
                }
            }
            else
            {
                // Jogador errou a sequência
                tempAudioSource.PlayOneShot(wrongSound); // Toca o som de erro
                ResetPuzzle();
            }

            // Após o som ser tocado, destroi o AudioSource temporário
            Destroy(tempAudioSource, correctSound.length); // Tempo do som de acerto
        }
    }

    // Função para resetar o puzzle quando o jogador errar
    private void ResetPuzzle()
    {
        currentStep = 0; // Reseta o progresso do jogador
        Debug.Log("Sequência errada! Recomece");
    }
}