using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Code.Logic.ShopSystem
{
    public class InventorySystem : MonoBehaviour
    {
        private readonly string _sceneName = "ShopScene";
        
        private Items _items;
        
        private DataValue _dataValue;
        
        private void Awake()
        {
            _items = GetComponent<Items>();
            SceneManager.sceneLoaded += LoadScene;
        }

        private void LoadScene(Scene nameScene, LoadSceneMode loadSceneMode)
        {
            if (nameScene.name == _sceneName) 
                BuyTools();
        }

        private void BuyTools() => 
            _items.PurchaseItem();
    }
}