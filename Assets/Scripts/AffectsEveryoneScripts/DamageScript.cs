using UnityEngine;

public class DamageScript : MonoBehaviour
{

    [SerializeField] private string targetTag;
    [SerializeField] private float minDamage = 5f;
    [SerializeField] private float maxDamage = 10f;



    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(targetTag))
        {
            LifeTotalScript targetLifeScript = collision.gameObject.GetComponent<LifeTotalScript>();
            targetLifeScript.DecreaseLife(Random.Range(minDamage,maxDamage));
        }
    }
}
