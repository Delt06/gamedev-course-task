using System.Linq;
using Collectibles;
using Collectibles.Extensions;
using Collectibles.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class CoinDisplay : MonoBehaviour
    {
        #pragma warning disable 0649

        [SerializeField] private CollectorController _collector;
        
        #pragma warning restore 0649
        
        private Text _textComponent;

        private void Awake()
        {
            _textComponent = GetComponent<Text>();

            _collector.Collected += (sender, coin) => ShowCoinsOf((ICollector) sender); 
            
            ShowCoinsOf(_collector);
        }

        private void ShowCoinsOf(ICollector collector)
        {
            _textComponent.text = collector.GetTotalCoinsValue().ToString();
        }
    }
}