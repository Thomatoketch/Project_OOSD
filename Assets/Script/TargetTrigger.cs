using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    public int points = 10; // Points donnés lorsqu'une cible est touchée

    void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant est une flèche
        if (other.CompareTag("Arrow"))
        {
            // Ajoute des points et désactive la cible (ou d'autres actions que tu veux)
            ScoreManager.AddPoints(points);
            Destroy(gameObject); // Optionnel : détruire la cible
        }
    }
}
