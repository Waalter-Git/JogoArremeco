using UnityEngine;

public class PapelController : MonoBehaviour
{
    public float forcaArremesso = 500f;
    public GameObject papelPrefab;  // Prefab do papel

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))  // Clique esquerdo do mouse
        {
            Arremessar();
        }
    }

    void Arremessar()
    {
        GameObject papel = Instantiate(papelPrefab, transform.position, transform.rotation);
        Rigidbody rb = papel.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * forcaArremesso);
    }
}
