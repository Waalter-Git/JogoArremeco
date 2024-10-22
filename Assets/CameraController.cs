using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensibilidadeMouse = 100f;  // Controla a sensibilidade do mouse

    private float rotacaoX = 0f;  // Acumula a rota��o no eixo X (vertical)
    private float rotacaoY = 0f;  // Acumula a rota��o no eixo Y (horizontal)

    void Start()
    {
        // Trava o cursor no centro da tela e esconde o ponteiro
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Captura o movimento do mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse * Time.deltaTime;

        // Atualiza a rota��o acumulada
        rotacaoX -= mouseY;
        rotacaoY += mouseX;

        // Limita a rota��o vertical para n�o inverter a vis�o
        rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f);

        // Aplica a rota��o acumulada em ambos os eixos
        transform.localRotation = Quaternion.Euler(rotacaoX, rotacaoY, 0f);
    }
}
