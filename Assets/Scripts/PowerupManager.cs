using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public Vector2 screenOffset = new Vector2(5, 5);
    public float spawnInterval = 7f; //interval in seconds 
    public List<GameObject> powerups = new List<GameObject>();


    private void Start()
    {
        StartCoroutine(PowerupLoop());
    }


    private Vector2 GetRandomPosition()
    {
        float x = UnityEngine.Random.Range(0 + screenOffset.x, Screen.width - screenOffset.x);
        float y = UnityEngine.Random.Range(0 + screenOffset.y, Screen.height - screenOffset.y);

        return Camera.main.ScreenToWorldPoint(new Vector2(x, y));
    }

    public IEnumerator PowerupLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            int index = UnityEngine.Random.Range(0, powerups.Count);

            SpawnPowerup(index, GetRandomPosition());

        }
    }

    void SpawnPowerup(int index, Vector2 pos)
    {
        Instantiate(powerups[index], pos, new Quaternion());
    }


}
