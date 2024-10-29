using UnityEngine;
using UnityEngine.UI;  // Necess�rio para manipular elementos UI

public class ShowController : MonoBehaviour
{
    public float forcaArremesso = 500f;      // For�a do arremesso
    public Transform playerCamera;           // Refer�ncia � c�mera do jogador
    public GameObject[] throwables;          // Array de objetos arremess�veis
    public Text objetoAtualText;             // Refer�ncia para o texto UI

    private int currentObjectIndex = 0;      // �ndice do objeto atualmente selecionado

    void Start()
    {
        AtualizarInterface();  // Atualiza a UI no in�cio
    }

    void Update()
    {
        // Detecta o clique do bot�o esquerdo do mouse
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
        // Instancia o objeto selecionado na posi��o e rota��o da c�mera
        GameObject throwable = Instantiate(
            throwables[currentObjectIndex],
            playerCamera.position + playerCamera.forward * 1f,  // Um pouco � frente da c�mera
            playerCamera.rotation
        );

        // Verifica se o objeto tem um Rigidbody
        Rigidbody rb = throwable.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(playerCamera.forward * forcaArremesso);  // Aplica for�a
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
