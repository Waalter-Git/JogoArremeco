using UnityEngine;

public class Lixeira : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Papel"))
        {
            Debug.Log("Acertou!");
            Destroy(other.gameObject);  // Remove o papel da cena
        }
    }
}
