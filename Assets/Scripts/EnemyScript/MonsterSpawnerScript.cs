
using UnityEngine;

public class MonsterSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private float monsterAmonut = 50f;
    [SerializeField] private bool spawnInfiniteMonsters = false;
    private float currentMonsterCount = 1;
    private Terrain terrain;
    private Vector3 terrainSize, terrainPosition;

    

    // Start is called before the first frame update
    void Start()
    {

        terrain = GetComponent<Terrain>();
        terrainSize = terrain.terrainData.size;
        terrainPosition = terrain.transform.position;

        for(int i =0; i<monsterAmonut;i++)
        {
            GenerateMonster();
            currentMonsterCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnInfiniteMonsters && currentMonsterCount<monsterAmonut)
        {
            GenerateMonster();
            currentMonsterCount++;
        }
    }

    public void MonsterKilled()
    {
        currentMonsterCount--;
        ScoreScript.Instance.AddScoreMonsterKilled();
        if(currentMonsterCount<=0 && !spawnInfiniteMonsters)
        {
            GameEndScript.Instance.GameEnded(true);
        }
    }


    void GenerateMonster()
    {
        float randomX = Random.Range(terrainPosition.x, terrainPosition.x + terrainSize.x);
        float randomZ = Random.Range(terrainPosition.z, terrainPosition.z + terrainSize.z);
        float terrainHeight = terrain.SampleHeight(new Vector3(randomX, 0, randomZ)) + terrainPosition.y;

        Vector3 spawnPosition = new Vector3(randomX, terrainHeight, randomZ);
        GameObject newMonster = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
        newMonster.tag = "Enemy";
    }
}
