/* Text Loader
 * load text in for Dialog
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
    public class UI_Dialog : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Change fill in rate speed")]
        [Range(0.01f, 0.1f)]
        private float _fillInRate = 0.2f;
        private Text _dialogbox;

        #region Unity Calls
        private void Awake()
        {
            _dialogbox = this.GetComponent<Text>();
            Color color = _dialogbox.color;
            color.a = 0f;
            _dialogbox.color = color;
        }
        #endregion

        #region public

        /// <summary>
        /// Toggle visablity of the text
        /// </summary>
        /// <param name="TurnOn">bool value for visablity</param>
        public void ToggleDialogBox(bool TurnOn)
        {
            _dialogbox.enabled = TurnOn;
        }
        

        /// <summary>
        /// Skip the fade in and show it fully
        /// </summary>
        public void ShowFullText()
        {
            Color color = _dialogbox.color;
            color.a = 255;
            _dialogbox.color = color;
            StopCoroutine(FadeTextIn());
        }

        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="ID">ID of text dialog to show</param>
        public void DialogShow(int ID)
        {
            _dialogbox.text= Dialog.TextLoader.GetDialog(ID);
            StartCoroutine(FadeTextIn());
            
        }

        #endregion

        #region Coroutines
        IEnumerator FadeTextIn()
        {

            Color color = _dialogbox.color;
            color.a = 0;
            for (float i = 0; i <= 1f; i=+_fillInRate)
            {
                color.a+= _fillInRate;
                _dialogbox.color = color;
                yield return new WaitForSeconds(0.1f);
            }
        }
        #endregion
    }
}