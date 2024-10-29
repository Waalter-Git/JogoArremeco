using UnityEngine;
using UnityEngine.UI;  // Necessário para manipular elementos UI

public class ShowController : MonoBehaviour
{
    public float forcaArremesso = 500f;      // Força do arremesso
    public Transform playerCamera;           // Referência à câmera do jogador
    public GameObject[] throwables;          // Array de objetos arremessáveis
    public Text objetoAtualText;             // Referência para o texto UI

    private int currentObjectIndex = 0;      // Índice do objeto atualmente selecionado

    void Start()
    {
        AtualizarInterface();  // Atualiza a UI no início
    }

    void Update()
    {
        // Detecta o clique do botão esquerdo do mouse
        if (Input.GetButtonDown("Fire1"))
        {
            Arremessar();
        }

        // Alterna entre os objetos com as setas do teclado
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SelecionarProximoObjeto();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SelecionarObjetoAnterior();
        }
    }

    void Arremessar()
    {
        // Instancia o objeto selecionado na posição e rotação da câmera
        GameObject throwable = Instantiate(
            throwables[currentObjectIndex],
            playerCamera.position + playerCamera.forward * 1f,  // Um pouco à frente da câmera
            playerCamera.rotation
        );

        // Verifica se o objeto tem um Rigidbody
        Rigidbody rb = throwable.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(playerCamera.forward * forcaArremesso);  // Aplica força
        }
    }

    void SelecionarProximoObjeto()
    {
        currentObjectIndex = (currentObjectIndex + 1) % throwables.Length;
        AtualizarInterface();  // Atualiza o nome na interface
    }

    void SelecionarObjetoAnterior()
    {
        currentObjectIndex = (currentObjectIndex - 1 + throwables.Length) % throwables.Length;
        AtualizarInterface();  // Atualiza o nome na interface
    }

    void AtualizarInterface()
    {
        // Atualiza o texto UI com o nome do objeto atual
        objetoAtualText.text = "Segurando: " + throwables[currentObjectIndex].name;
    }
}
