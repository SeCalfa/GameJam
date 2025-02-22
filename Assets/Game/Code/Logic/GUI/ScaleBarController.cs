using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Game.Code.Logic.GUI
{
    public class ScaleBarController : MonoBehaviour
    {
        private Image _image;
        
        public void SetBarValue(float value) => 
            _image.fillAmount = value;
    }
}