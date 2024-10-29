using UnityEngine;

public class PapelController : MonoBehaviour
{
    public float forcaArremesso = 500f;
    //public GameObject papelPrefab;  // Prefab do papel
    private int selectedObject = 0;   // Índice do objeto selecionado
    public Transform playerCamera;
    public GameObject[] throwables;   // Objetos arremessáveis

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) selectedObject = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) selectedObject = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) selectedObject = 2;


        if (Input.GetButtonDown("Fire1"))  // Clique esquerdo do mouse
        {
            Arremessar();
        }
    }

    void Arremessar()
    {
        //GameObject papel = Instantiate(papelPrefab, transform.position, transform.rotation);

        //GameObject throwable = Instantiate(throwables[selectedObject], transform.position, transform.position);
        GameObject throwable = Instantiate(throwables[selectedObject], playerCamera.position, playerCamera.rotation);
        //Rigidbody rb = papel.GetComponent<Rigidbody>();

        Rigidbody rb = throwable.GetComponent<Rigidbody>();


        //rb.AddForce(transform.forward * forcaArremesso);
        rb.AddForce(playerCamera.forward * forcaArremesso);
    }
}