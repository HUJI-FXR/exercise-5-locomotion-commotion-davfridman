using UnityEngine;

public class TintEnemyRedScript : MonoBehaviour
{
    private MonsterSpawnerScript monsterSpawnerScript;
    private LifeTotalScript lifeTotalScript;
    private Renderer[] renderers;
    public Color colorToSet = Color.red;
    void Start()
    {
        monsterSpawnerScript = Terrain.activeTerrain.GetComponent<MonsterSpawnerScript>();
        lifeTotalScript = GetComponent<LifeTotalScript>();
        renderers = GetComponentsInChildren<Renderer>();
    }


    void Update()
    {
        float lifeLeftRatio = lifeTotalScript.GetLeftLifeRatio();
        Color colorToSet = lifeLeftRatio * Color.white + (1f - lifeLeftRatio) * Color.red;
        foreach (Renderer renderer in renderers)
        {
            if(renderer != null)
            {
                renderer.material.color = colorToSet;
            }
        }
    }
}
