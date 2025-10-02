using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    [SerializeField] private ItemDatabase itemDatabase;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        itemDatabase.Init();
    }

    public GameObject GetItem(eNormalType type)
    {
        return itemDatabase.GetItem(type);
    }
    public GameObject GetItem(eBonusType type)
    {
        return itemDatabase.GetItem(type);
    }
}
