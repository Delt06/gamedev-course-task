using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class RestartScreen : MonoBehaviour
    {
        #pragma warning disable 0649
        
        [SerializeField] private PlayerController _player;
        [SerializeField, Range(0.01f, 10f)] private float _delay = 1f;
        
        #pragma warning restore 0649
        
        private void Awake()
        {
            ChildrenSetActive(false);
            
            _player.Death += (sender, args) => StartCoroutine(ShowCoroutine());
        }

        private IEnumerator ShowCoroutine()
        {
            yield return new WaitForSeconds(_delay);
            
            ChildrenSetActive(true);
        }

        private void ChildrenSetActive(bool active)
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                child.gameObject.SetActive(active);
            }
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}