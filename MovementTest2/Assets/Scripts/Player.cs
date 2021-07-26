using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class Player : Singleton<Player>
{
    private SpriteRenderer spriteRenderer;
    private Inventory inventory;
    private Vector3Int cellPosition;
    private Vector3 cell;
    public GameObject players;
    private GrowthInfo growthInfo;
    public Tilemap map;
    public Tilemap plantMap;
    public List<GameObject> holder = new List<GameObject>();

    private int i = 0;


    [SerializeField] InventoryUI uiInventory;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);

        ItemWorld.SpawnItemWorld(new Vector3(-2, -1), new Item(1) {amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(2, -2), new Item(2) {amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(1, -1), new Item(5) {amount = 1});


    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();

        if(itemWorld != null && inventory.IsNotFull() && i == 0)
        {
            //Touching Item
            inventory.AddItem(itemWorld.GetItem());
            i++;
            itemWorld.DestroySelf();
            i = 0;

        }
        if(!inventory.IsNotFull())
        {
            Debug.Log("Inventory is full!");
        }
    }
/*     private void OnTriggerExit2D(Collider2D other)
    {
        if (i == 1 && other.GetComponent<ItemWorld>() != null)
        {
            i = 0;
        }
    } */

         

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            uiInventory.Selector();
        }
        
    }

    public void Grow()
    {
        foreach(GameObject seedlings in holder)
        {
            growthInfo = seedlings.GetComponent<GrowthInfo>();
            growthInfo.OnGrowEvent.Invoke();
            int holde = growthInfo.growthStage;
            seedlings.GetComponent<SpriteRenderer?>().sprite = growthInfo.growths[holde];
            growthInfo.ReturnGrowthPos(seedlings.transform.position);



            //Testing
            Debug.Log("Plant " + seedlings.name + " grew to growth " + growthInfo.ReturnGrowthStage());
            Debug.Log(growthInfo.IsFinalStage());
        }
        
    }
    private void Plant(GameObject seed)
    {
        cell = plantMap.GetCellCenterWorld(map.WorldToCell(players.transform.position));
        holder.Add(Instantiate(seed, cell, Quaternion.identity));
    }
    private void UseItem(Item item)
    {
        foreach(KeyValuePair<int, ItemInfo> kvp in item.itemTypes)
        {
            int key = kvp.Key;
            ItemInfo itemInfo = kvp.Value;
            if(item.id == key)
            {
                if(itemInfo.itemType == ItemInfo.ItemType.Seed)
                {
                    Plant(itemInfo.seedPrefab);
                    inventory.RemoveItem(new Item(item.id){amount = 1});
                }
                else if(itemInfo.itemType == ItemInfo.ItemType.Tool)
                {
                    var toolInteractable = itemInfo.toolPrefab.GetComponent<IToolInteract>();
                    toolInteractable.UseTool();
                }
            }
        }
    }
}
