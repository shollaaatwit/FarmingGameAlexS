using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GrowthInfo : MonoBehaviour
{   
    public static GrowthInfo Instance;
    public Sprite[] growths;
    public int growthStage;
    public UnityEvent OnGrowEvent;
    public Player player;

    public Vector3 positionOfPlant;

    public int droppedItemsID;
    public int amountToDrop;

    public bool finalStage;

    void Start()
    {
        player = GameObject.Find("test player sprite").GetComponent<Player>();
    }
    void Update()
    {
        finalStage = (growthStage == growths.Length-1);
    }

    public bool IsFinalStage()
    { 
        return growthStage == growths.Length-1;
    }   

    public void IncrementGrowthStage()
    {
        if(IsFinalStage())
        {
            growthStage = growthStage;
        }
        else
        {
            growthStage++;

        }
    }

    public void ReturnGrowthPos(Vector3 pos)
    {
        positionOfPlant = pos;
    }

    public int ReturnGrowthStage()
    {
        return growthStage;
    }

    public Sprite ReturnSpecificGrowthStage(int index)
    {
        return growths[index];
    }

    public Sprite[] ReturnGrowthSprites()
    {
        return growths;
    }

    public void DestroyPlant()
    {
        player.holder.Remove(gameObject);
        Destroy(gameObject);
    }

}
