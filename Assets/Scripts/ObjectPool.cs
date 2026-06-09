using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    int maxPerColor = 14;

    GameManager gameManager;

    void Start()
    {
        gameManager = GetComponent<GameManager>();

        CreateColor(gameManager.red);
        CreateColor(gameManager.orange);
        CreateColor(gameManager.yellow);
        CreateColor(gameManager.green);
        CreateColor(gameManager.blue);
        CreateColor(gameManager.navy);
        CreateColor(gameManager.purple);
    }

    void CreateColor(GameObject color)
    {
        for (int i = 0; i < maxPerColor; i++)
        {
            GameObject obj = Instantiate(color);
            obj.SetActive(false);
        }
    }
void Update()
    {
        
    }
}
