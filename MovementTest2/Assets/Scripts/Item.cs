using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public bool isSelected {get; set;}

    public string title;
    public int id;
    public Item(int id)
    {
        this.id = id;
    }


    //Organized Dictionary of item sprites, prefabs, and future information they need
    // 0 being defaulted to null if need be, dictionary will be organized by itemtypes starting with seeds
    public Dictionary<int, ItemInfo> itemTypes = new Dictionary<int, ItemInfo>()
    {
        {0, null},
        {1, new ItemInfo(ItemAssets.Instance.pumpkinSeedSprite){itemType = ItemInfo.ItemType.Seed,
                                                                seedPrefab = ItemAssets.Instance.pumpkinSeed}},
        {2, new ItemInfo(ItemAssets.Instance.tomatoSeedSprite){itemType = ItemInfo.ItemType.Seed, 
                                                                seedPrefab = ItemAssets.Instance.tomatoSeed}},




        {3, new ItemInfo(ItemAssets.Instance.tomatoSprite){itemType = ItemInfo.ItemType.Plant}},
        

                                                                
        {4, new ItemInfo(ItemAssets.Instance.pumpkinSprite){itemType = ItemInfo.ItemType.Plant}},


        {5, new ItemInfo(ItemAssets.Instance.stickSprite){itemType = ItemInfo.ItemType.Tool,
                                                            toolPrefab = ItemAssets.Instance.stickTool}},

        
    };


    // Note for me tomorrow :
    // Create stick option with similar method to growing but for harvesting
    // Add a drop method amount to growthinfo
    // use itemworld to physically drop items from plants
    // use action controller technique in coding from movementtest1 to optimize the if statements in the player class // fuck

    public int amount;
    public Sprite GetSprite(int myKey)
    {
        return itemTypes[myKey]?.itemSprite;
    }

}
