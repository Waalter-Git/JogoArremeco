using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public int score = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Throwable"))
        {
            // Verifique se o objeto está acima da lixeira
            if (other.transform.position.y > transform.position.y)
            {
                score += 10;
                Destroy(other.gameObject);
                Debug.Log("Pontuação: " + score);
            }
        }
    }
}
