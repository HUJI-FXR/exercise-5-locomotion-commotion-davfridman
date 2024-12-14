using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private LifeTotalScript playerLifeTotal;
    private TMPro.TextMeshProUGUI healthScore;
    
    // Start is called before the first frame update
    void Start()
    {
        healthScore = GetComponent<TMPro.TextMeshProUGUI>();
        playerLifeTotal = player.GetComponent<LifeTotalScript>();
    }

    // Update is called once per frame
    void Update()
    {
        healthScore.text = 
            $"Health: {Mathf.RoundToInt(playerLifeTotal.GetLifeTotal())}/{Mathf.RoundToInt(playerLifeTotal.GetInitialLifeTotal())}";
    }
}
