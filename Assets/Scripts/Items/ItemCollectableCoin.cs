using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    public int amount = 1;
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins(amount);
    }
}
