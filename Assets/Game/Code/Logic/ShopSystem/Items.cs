using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.Logic.ShopSystem
{
    public class Items : MonoBehaviour
    {
        private DataValue _data;
        
        public Dictionary<GameObject, int> ItemsList;

        [SerializeField]
        private GameObject _item1;
        [SerializeField]
        private GameObject _item2;
        [SerializeField]
        private GameObject _item3;

        private void Awake()
        {
            ItemsList = new Dictionary<GameObject, int>()
            {
                { _item1, 10 },
                { _item2, 7 },
                { _item3, 12 },
            };
        }
        
        public void PurchaseItem()
        {
            foreach (KeyValuePair<GameObject, int> pair in ItemsList)
            {
                if (pair.Value >= _data.CurrentValue)
                {
                    _data.CurrentValue -= pair.Value;
                    AddItemToPlayer(pair.Key, pair.Value);
                    
                }
            }
        }

        private void AddItemToPlayer(GameObject pairKey, int pairValue)
        {
            
        }
    }
}