using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    public int points = 10; // Points donn�s lorsqu'une cible est touch�e

    void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet entrant est une fl�che
        if (other.CompareTag("Arrow"))
        {
            // Ajoute des points et d�sactive la cible (ou d'autres actions que tu veux)
            ScoreManager.AddPoints(points);
            Destroy(gameObject); // Optionnel : d�truire la cible
        }
    }
}
