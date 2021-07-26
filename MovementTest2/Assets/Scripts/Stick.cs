using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour, IToolInteract
{
    public void UseTool()
    {

        DestroyCrop(range, plant);
    }

    public float range;
    public Transform toolPos;
    public LayerMask plant;
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(toolPos.position, range);
    }




    public void DestroyCrop(float harvestRange, LayerMask whatArePlants)
    {

        Collider2D[] plantsToHarvest = Physics2D.OverlapCircleAll(toolPos.position, harvestRange, whatArePlants);
        Debug.Log("Got to DestroyCrop");
        foreach(Collider2D plants in plantsToHarvest)
        {
            Debug.Log("Got to inside the foreach loop");

            GrowthInfo info = plants.GetComponent<GrowthInfo>();

                if(info.IsFinalStage())
                {
                    Debug.Log("Got to inside the If Statement");
                    DropItems(new Item(info.droppedItemsID), info.positionOfPlant, info.amountToDrop);
                    info.DestroyPlant();
                }
        }
    }

    public void DropItems(Item item, Vector3 position, int amount)
    {
        for(int x = 0; x < amount; x++)
        {
            ItemWorld.SpawnItemWorld(position, item);
        }
    }
}
