using UnityEngine;

public class Controller : MonoBehaviour
{
    public float forcaArremesso = 500f;      // Força do arremesso
    public Transform playerCamera;           // Referência à câmera do jogador
    public GameObject[] throwables;          // Array de objetos arremessáveis

    void Update()
    {
        // Detecta o clique do botão esquerdo do mouse
        if (Input.GetButtonDown("Fire1"))
        {
            Arremessar();
        }
    }

    void Arremessar()
    {
        // Verificar se há objetos arremessáveis disponíveis no array
        if (throwables.Length == 0)
        {
            Debug.LogWarning("Nenhum objeto disponível para arremesso.");
            return;
        }

        // Seleciona um objeto aleatório do array de arremessáveis
        int randomIndex = Random.Range(0, throwables.Length);

        // Instancia o objeto selecionado na posição e rotação da câmera
        GameObject throwable = Instantiate(
            throwables[randomIndex],
            playerCamera.position + playerCamera.forward * 1f, // Um pouco à frente da câmera
            playerCamera.rotation
        );

        // Verifica se o objeto tem um Rigidbody
        Rigidbody rb = throwable.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("O objeto arremessável não possui um Rigidbody.");
            return;
        }

        // Aplica a força de arremesso na direção da câmera
        rb.AddForce(playerCamera.forward * forcaArremesso);
    }
}
