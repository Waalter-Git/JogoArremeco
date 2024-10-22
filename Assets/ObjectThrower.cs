using UnityEngine;

public class ObjectThrower : MonoBehaviour
{
    public GameObject[] throwables;   // Objetos arremessáveis
    public Transform playerCamera;    // Câmera do jogador
    public Transform playerBody;      // Corpo do jogador
    public float throwForce = 500f;   // Força do arremesso
    private int selectedObject = 0;   // Índice do objeto selecionado

    void Update()
    {
        // Alternar objetos com teclas 1, 2 e 3
        if (Input.GetKeyDown(KeyCode.Alpha1)) selectedObject = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) selectedObject = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) selectedObject = 2;

        // Arremessar objeto ao pressionar o botão de disparo
        if (Input.GetButtonDown("Fire1"))
        {
            ThrowObject();
        }
    }

    void ThrowObject()
    {
        // Definir a posição inicial do objeto levemente à frente da câmera
        Vector3 spawnPosition = playerCamera.position + playerCamera.forward * 1f;

        // Instanciar o objeto arremessável
        GameObject throwable = Instantiate(throwables[selectedObject], spawnPosition, Quaternion.identity);

        // Adicionar ou garantir que o objeto tenha um Rigidbody
        Rigidbody rb = throwable.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = throwable.AddComponent<Rigidbody>();
        }

        // Ignorar colisão entre o corpo do jogador e o objeto arremessado
        Collider objectCollider = throwable.GetComponent<Collider>();
        Collider playerCollider = playerBody.GetComponent<Collider>();

        if (objectCollider != null && playerCollider != null)
        {
            Physics.IgnoreCollision(objectCollider, playerCollider);
        }

        // Usar TransformDirection para garantir a direção correta, sem limitar por eixo
        Vector3 throwDirection = playerCamera.TransformDirection(Vector3.forward);

        // Resetar a velocidade para evitar interferências anteriores
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Aplicar a força na direção correta
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
    }
}
