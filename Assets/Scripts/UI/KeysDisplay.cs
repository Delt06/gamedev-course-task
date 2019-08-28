using System.Linq;
using Collectibles;
using Collectibles.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class KeysDisplay : MonoBehaviour
    {
#pragma warning disable 0649

        [SerializeField] private CollectorController _collector;
        
#pragma warning restore 0649
        
        private Text _textComponent;

        private void Awake()
        {
            _textComponent = GetComponent<Text>();

            _collector.Collected += (sender, coin) => ShowKeysOf((CollectorController) sender); 
            
            ShowKeysOf(_collector);
        }

        private void ShowKeysOf(CollectorController collector)
        {
            _textComponent.text = _collector.Collectibles
                .OfType<IKey>()
                .Count()
                .ToString();
        }
    }
}