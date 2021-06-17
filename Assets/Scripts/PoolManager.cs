using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private static PoolManager _instance;

    public static PoolManager Instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("PoolManager is null!");
            return _instance;
        }
    }
    
    private List<GameObject> _list;

    public GameObject sandwichPrefab;

    public Transform container;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Generate list contains 10 game objects
        _list = GenerateSandwich(10);
    }

    private List<GameObject> GenerateSandwich(int amout)
    {
        List<GameObject> newList = new List<GameObject>();
        for (int i = 0; i < amout; i++)
        {
            // Instantiate sandwich game object
            GameObject sandwich = Instantiate(sandwichPrefab);
            // Set parent for sandwich game object
            sandwich.transform.parent = container;
            // Set sandwich game object to false
            sandwich.SetActive(false);
            // add sandwich game object to newlist
            newList.Add(sandwich);
        }
        return newList;
    }

    public GameObject RequestSandwich()
    {
        foreach (GameObject sandwich in _list)
        {
            // Check if sandwich is not active
            if (!sandwich.gameObject.activeInHierarchy)
            {
                sandwich.SetActive(true);
                return sandwich;
            }
        }
        
        // if out of list sandwich then Instantiate new sandwich game object
        GameObject newSandwich = Instantiate(sandwichPrefab);
        newSandwich.transform.parent = container;
        _list.Add(newSandwich);
        return newSandwich;
    }
}
