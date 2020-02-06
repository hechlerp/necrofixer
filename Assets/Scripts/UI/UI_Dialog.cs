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
    public class UI_Dialog : MonoBehaviour {
        [SerializeField]
        [Tooltip("Change fill in rate speed")]
        [Range(0.02f, 0.3f)]
        private float _fillInRate = 0.2f;
        private Text _dialogbox;
        public string sourceTextName;
        string textToShow;

        #region Unity Calls
        private void Awake() {
            textToShow = "";
            _dialogbox = GetComponent<Text>();
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
        public void ToggleDialogBox(bool TurnOn) {
            _dialogbox.enabled = TurnOn;
        }


        /// <summary>
        /// Skip the fade in and show it fully
        /// </summary>
        public void ShowFullText() {
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
            textToShow = Dialog.TextLoader.GetDialog(ID);
            _dialogbox.text = textToShow;
            StartCoroutine(FadeTextIn());
            
        }

        public void setFinishAction(System.Action action) {
            transform.parent.GetChild(1).GetComponent<ButtonNext>().onFinishDialogue = action;
        }

        #endregion

        #region Coroutines
        IEnumerator FadeTextIn()
        {
            string coroutineText = textToShow;
            Color color = _dialogbox.color;
            color.a = 0;
            for (float i = 0; i <= 1f; i+=_fillInRate)
            {
                if (coroutineText != textToShow) {
                    i = 1f;
                }
                color.a+= _fillInRate;
                _dialogbox.color = color;
                yield return new WaitForSeconds(0.1f);
            }
        }
        #endregion
    }
}