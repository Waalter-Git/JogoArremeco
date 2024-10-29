using UnityEngine;

public class Controller : MonoBehaviour
{
    public float forcaArremesso = 500f;      // For�a do arremesso
    public Transform playerCamera;           // Refer�ncia � c�mera do jogador
    public GameObject[] throwables;          // Array de objetos arremess�veis

    void Update()
    {
        // Detecta o clique do bot�o esquerdo do mouse
        if (Input.GetButtonDown("Fire1"))
        {
            Arremessar();
        }
    }

    void Arremessar()
    {
        // Verificar se h� objetos arremess�veis dispon�veis no array
        if (throwables.Length == 0)
        {
            Debug.LogWarning("Nenhum objeto dispon�vel para arremesso.");
            return;
        }

        // Seleciona um objeto aleat�rio do array de arremess�veis
        int randomIndex = Random.Range(0, throwables.Length);

        // Instancia o objeto selecionado na posi��o e rota��o da c�mera
        GameObject throwable = Instantiate(
            throwables[randomIndex],
            playerCamera.position + playerCamera.forward * 1f, // Um pouco � frente da c�mera
            playerCamera.rotation
        );

        // Verifica se o objeto tem um Rigidbody
        Rigidbody rb = throwable.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("O objeto arremess�vel n�o possui um Rigidbody.");
            return;
        }

        // Aplica a for�a de arremesso na dire��o da c�mera
        rb.AddForce(playerCamera.forward * forcaArremesso);
    }
}
