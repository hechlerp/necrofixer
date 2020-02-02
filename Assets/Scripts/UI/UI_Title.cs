/* Title text 
 * Title Text Fliter
 * 
 * Scott Tongue
 * 2020
 */

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace ToolUI
{
    [RequireComponent(typeof(Text))]
    public class UI_Title : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Change fill in rate speed")]
        [Range(0.01f, 0.1f)]
        private float _fillInRate = 0.2f;

        private Text _title;

        #region Unity Calls
        #endregion

        private void OnEnable()
        {
            _title = this.GetComponent<Text>();
            StartCoroutine(FadeTextInAndOut());
        }
        private void OnDisable()
        {
            StopCoroutine(FadeTextInAndOut());
        }


        #region Coroutines
        IEnumerator FadeTextInAndOut()
        {

            Color color = _title.color;
            color.a = 0;
            while (true)
            {
                for (float i = 0; i <= 1f; i += _fillInRate)
                {
                  
                    color.a += _fillInRate;
                    _title.color = color;
                    yield return new WaitForSeconds(0.1f);
                }

                for (float i = 1; i >= 0f; i -=_fillInRate)
                {
                    color.a -= _fillInRate;
                    _title.color = color;
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
        #endregion
    }
}