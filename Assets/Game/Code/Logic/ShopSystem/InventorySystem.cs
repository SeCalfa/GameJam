using UnityEngine;

namespace Game.Code.Logic.ShopSystem
{
    public class InventorySystem : MonoBehaviour
    {
        private string _sceneName;
        
        private Items _items;
        
        private DataValue _dataValue;

        public string CurrentScene;
        
        private void BuyTools()
        {
            if (CurrentScene == _sceneName)
            {
                _items.PurchaseItem();
            }
        }
    }
}