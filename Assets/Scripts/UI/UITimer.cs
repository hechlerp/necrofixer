using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ToolUI
{
    [RequireComponent(typeof(TimerClock))]
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
            _timer = this.GetComponent<TimerClock>();
        }
        private void OnDisable()
        {
            DelegateCleanUp();
        }

        private void Start()
        {
            TimerControllerManager.AddTimer(this.gameObject, _timer);
            TimerControllerManager.GetTimer(this.gameObject).SetupTimer(10f);
            StartTimer(this.gameObject);
        }
        #endregion

        #region public

        /// <summary>
        /// Setup the timer in the UI based on gameobject
        /// </summary>
        /// <param name="gameObject">Gameobject that the timer is set to</param>
        public void StartTimer(GameObject gameObject)
        {
            DelegateCleanUp();

            _timer = TimerControllerManager.GetTimer(gameObject);
            if (_timer == null)
            {
                Debug.LogError(gameObject + " Doesn't have timer set to it");
                return;
            }
            else
            {
                _timer.TimerEnded += TimeFinished;
                _timer.TimerRemused += TimeResume;
                _timer.TimerPaused += TimePause;
                _timer.TimeRemoved += DelegateCleanUp;
              
                _popTimeOver.SetActive(false);
                StartCoroutine(UpdateImageFill());
            }


        }
        #endregion

        #region private

        //CLEAN UP OUR MEMORY LEAKS == BAD LITTLE HORSEY CODER
        //"A Plea for Lean  and CLEAN Software"
        private void DelegateCleanUp()
        {
            if (_timer == null)
                return;

            _timer.TimerEnded -= TimeFinished;
            _timer.TimerRemused -= TimeResume;
            _timer.TimerPaused -= TimePause;
            _timer.TimeRemoved -= DelegateCleanUp;
            
        }

        private void TimePause()
        {
            StopCoroutine(UpdateImageFill());
        }

        private void TimeResume()
        {
            StartCoroutine(UpdateImageFill());
        }

        private void TimeFinished()
        {
            _popTimeOver.SetActive(true);
            StopCoroutine(UpdateImageFill());
        }
        #endregion

        #region Coroutines

        IEnumerator UpdateImageFill()
        {
            while (_timer.TimeCount > 0f)
            {
                if (_timer.TimeCount <= 0f)
                {
                    _timeImage.fillAmount = 0f;
                    yield break;
                }

                _timeImage.fillAmount = _timer.TimeCount / _timer.MaxTime;
                yield return new WaitForSeconds(.1f);
            }
            _timeImage.fillAmount = 0f;
        }
        #endregion

    }
}