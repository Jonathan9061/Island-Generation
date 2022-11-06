using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandGenerator : MonoBehaviour
{
    [Header ("GameObjects Chosen From")]
    public GameObject[] Islands;
    public GameObject[] Mountains;

    [Header("Amounts To Spawn (x/y = min/max)")]
    public Vector2 IslandVals;
    public Vector2 MountainVals;

    [Header("Island Modifiers")]
    public Vector2 MinMaxRot;
    public Vector2 MinMaxSize;
    public Vector2 MinMaxSizeVariation;
    public Vector2 MaxPosition;
    // Start is called before the first frame update
    void Start()
    {
        PlaceIslands();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlaceIslands()
    {
        for (int i = 0; i < Random.Range(IslandVals.x, IslandVals.y); i++)
        {
            Quaternion IslandRotation = transform.rotation * Quaternion.Euler(0, Random.Range(MinMaxRot.x, MinMaxRot.y), 0);
            Vector3 IslandPosition = new Vector3(Random.Range(-MaxPosition.x, MaxPosition.x), 0, Random.Range(-MaxPosition.y, MaxPosition.y));
            float IslandBaseSize = Random.Range(MinMaxSize.x, MinMaxSize.y);
            Vector3 IslandDimensions = new Vector3(IslandBaseSize + Random.Range(MinMaxSizeVariation.x, MinMaxSizeVariation.y), IslandBaseSize + Random.Range(MinMaxSizeVariation.x, MinMaxSizeVariation.y), IslandBaseSize + Random.Range(MinMaxSizeVariation.x, MinMaxSizeVariation.y));
            GameObject Island = Instantiate(Islands[Random.Range(0, Islands.Length)], IslandPosition, IslandRotation);
            Island.transform.localScale = IslandDimensions;
        }
    }
}
