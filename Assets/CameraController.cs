using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensibilidadeMouse = 100f;  // Controla a sensibilidade do mouse

    private float rotacaoX = 0f;  // Acumula a rotação no eixo X (vertical)
    private float rotacaoY = 0f;  // Acumula a rotação no eixo Y (horizontal)

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

        // Atualiza a rotação acumulada
        rotacaoX -= mouseY;
        rotacaoY += mouseX;

        // Limita a rotação vertical para não inverter a visão
        rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f);

        // Aplica a rotação acumulada em ambos os eixos
        transform.localRotation = Quaternion.Euler(rotacaoX, rotacaoY, 0f);
    }
}
