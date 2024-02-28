using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform spawnerTransform;
    GameObject currentObjectWord;
    public static WordSpawner Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void SpawnWord(GameObject wordPrefab)
    {
        StopAllCoroutines();
        StartCoroutine(InstatntiateWord(wordPrefab));
    }

    IEnumerator InstatntiateWord(GameObject wordPrefab)
    {
        if(currentObjectWord!= null)
        {
            Destroy(currentObjectWord);
        }
        yield return new WaitForEndOfFrame();
        currentObjectWord= Instantiate(wordPrefab, spawnerTransform.position, Quaternion.identity);
    }
}
