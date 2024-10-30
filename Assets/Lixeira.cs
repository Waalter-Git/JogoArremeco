using UnityEngine;
using TMPro;

public class Lixeira : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextColor;
    void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.CompareTag("Papel"))
        {
            score++;
            Debug.Log("Acertou!");
            Destroy(other.gameObject);  // Remove o papel da cena
            scoreText.text = score.ToString();
            scoreTextColor.text = score.ToString();
        }
    }
}
