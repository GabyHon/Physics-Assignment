using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regionManager : MonoBehaviour
{
    public GameObject regionPrefab;
    public float xMin = -5f;
    public float xMax = 5f;
    public float yMin = -5f;
    public float yMax = 5f;
    public float spawnInterval;

    public int minValue;
    public int maxValue;

    private float timer;

    public GameObject objectPrefab;
    private bool isObjectSpawned = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // creating random regions between a restricted area
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            float x = Random.Range(xMin, xMax);
            float y = Random.Range(yMin, yMax);
            Vector3 position = new Vector3(x, y, 0f);
            GameObject region = Instantiate(regionPrefab, position, Quaternion.identity);

            int value = Random.Range(minValue, maxValue);
            region.gameObject.GetComponent<region>().scoreValue = value;

            timer = 0f;
            spawnInterval = Random.Range(1f, 5f);
        }

        if (!isObjectSpawned)
        {
            Instantiate(objectPrefab, transform.position, Quaternion.identity);
            isObjectSpawned = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Puck")
        {
            Destroy(other.gameObject);
            isObjectSpawned = false;
        }
    }
}
