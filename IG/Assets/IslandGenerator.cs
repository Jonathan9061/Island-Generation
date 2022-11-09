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
    public Vector2 IMinMaxRot;
    public Vector2 IMinMaxSize;
    public Vector2 IMinMaxSizeVariation;
    public Vector2 IMaxPosition;

    [Header("Mountain Modifiers")]
    public Vector2 MMinMaxRot;
    public Vector2 MMinMaxSize;
    public Vector2 MMinMaxSizeVariation;
    public Vector2 MMaxPosition;
    // Start is called before the first frame update
    void Start()
    {
        PlaceIslands();
        PlaceMountains();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlaceIslands()
    {
        for (int i = 0; i < Random.Range(IslandVals.x, IslandVals.y); i++)
        {
            Quaternion IslandRotation = transform.rotation * Quaternion.Euler(0, Random.Range(IMinMaxRot.x, IMinMaxRot.y), 0);
            Vector3 IslandPosition = new Vector3(Random.Range(-IMaxPosition.x, IMaxPosition.x), 0, Random.Range(-IMaxPosition.y, IMaxPosition.y));
            float IslandBaseSize = Random.Range(IMinMaxSize.x, IMinMaxSize.y);
            Vector3 IslandDimensions = new Vector3(IslandBaseSize + Random.Range(IMinMaxSizeVariation.x, IMinMaxSizeVariation.y), IslandBaseSize + Random.Range(IMinMaxSizeVariation.x, IMinMaxSizeVariation.y), IslandBaseSize + Random.Range(IMinMaxSizeVariation.x, IMinMaxSizeVariation.y));
            GameObject Island = Instantiate(Islands[Random.Range(0, Islands.Length)], IslandPosition, IslandRotation);
            Island.transform.localScale = IslandDimensions;
        }
    }

    void PlaceMountains()
    {
        for (int i = 0; i < Random.Range(MountainVals.x, MountainVals.y); i++)
        {
            Quaternion IslandRotation = transform.rotation * Quaternion.Euler(0, Random.Range(MMinMaxRot.x, MMinMaxRot.y), 0);
            Vector3 IslandPosition = new Vector3(Random.Range(-MMaxPosition.x, MMaxPosition.x), 0, Random.Range(-MMaxPosition.y, MMaxPosition.y));
            float IslandBaseSize = Random.Range(MMinMaxSize.x, MMinMaxSize.y);
            Vector3 IslandDimensions = new Vector3(IslandBaseSize + Random.Range(MMinMaxSizeVariation.x, MMinMaxSizeVariation.y), IslandBaseSize + Random.Range(MMinMaxSizeVariation.x, MMinMaxSizeVariation.y), IslandBaseSize + Random.Range(MMinMaxSizeVariation.x, MMinMaxSizeVariation.y));
            GameObject Island = Instantiate(Mountains[Random.Range(0, Mountains.Length)], IslandPosition, IslandRotation);
            Island.transform.localScale = IslandDimensions;
        }
    }
}
