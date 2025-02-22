using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            _data = new DataValue(1);
            
            ItemsList = new Dictionary<GameObject, int>()
            {
                { _item1, 10 },
                { _item2, 7 },
                { _item3, 12 },
            };
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("ShopScene");
            }
        }
        
        public void PurchaseItem()
        {
            foreach (KeyValuePair<GameObject, int> pair in ItemsList)
            {
                if (_data.CurrentValue >= pair.Value)
                {
                    _data.CurrentValue -= pair.Value;
                    AddItemToPlayer(pair.Key, pair.Value);
                }
                else
                {
                    Debug.Log("Not enough money");
                }
            }
        }

        private void AddItemToPlayer(GameObject pairKey, int pairValue) => 
            Debug.Log("Item was added to player");
    }
}