using UnityEngine;

public class RandomSegmentGenerator : MonoBehaviour {
    public GameObject platform;
    public GameObject breakingPlatform;
    public GameObject springPlatform;

    void Start() {
        GameObject selectedPlatform;
        float x = Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2);;
        float y = transform.position.y - transform.localScale.y / 2;
        Vector3 spawnPosition;

        while (y < transform.position.y + transform.localScale.y / 2) {
            float randomValue = Random.value;

            if (randomValue < 0.5f) selectedPlatform = platform;
            else if (randomValue < 0.9f) selectedPlatform = breakingPlatform;
            else selectedPlatform = springPlatform;

            spawnPosition = new Vector3(x, y, transform.position.z);
            GameObject newPlatform = Instantiate(selectedPlatform, spawnPosition, Quaternion.identity);
            newPlatform.transform.parent = transform;

            x = Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2);
            y = Random.Range(y+0.25f, Random.Range(y+0.25f, y+4f));
        }
    }
}