using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToolsUI
{
    [RequireComponent(typeof(Image))]
    public class UITimer : MonoBehaviour
    {
        [SerializeField]
        private GameObject _popTimeOver = null;
        private Image _timeImage;
        private TimerClock _timer = null;
        #region Unity callback

        private void Awake()
        {
            _timeImage = this.GetComponent<Image>();
        }
        private void OnDisable()
        {
            DelegateCleanUp();
        }

        #endregion

        #region public

        public void StartTimer(GameObject gameObject)
        {

            _timer = TimerControllerManager.GetTimer(gameObject);
            if (_timer == null)
            {
                Debug.LogError(gameObject + " Doesn't have timer set to it");
                return;
            }
            else
            {
                _timer.TimerEnded += TimeFinished;
                _timer.TimeRemoved += DelegateCleanUp;
                _popTimeOver.SetActive(false);
                StartCoroutine(UpdateImageFill());
             //   Image fill = new Image;
            //    Image.f
            }


        }
        #endregion

        #region private

        private void DelegateCleanUp()
        {
            if (_timer == null)
                return;

            _timer.TimerEnded -= TimeFinished;
            _timer.TimeRemoved -= DelegateCleanUp;
        }

        private void TimeFinished()
        {
            _popTimeOver.SetActive(true);
            StopCoroutine(UpdateImageFill());
        }
        #endregion

        IEnumerator UpdateImageFill()
        {
            while (_timer.TimeCount > 0f) 
            {
                if (_timer.TimeCount <= 0f)
                    yield break;
                //_timeImage.t
                yield return new WaitForSeconds(.1f);
            }
        }

    }
}