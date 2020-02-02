using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TimerClock))]
public class SystemMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject _FrontScreen, _Menu, _Credit;
    private TimerClock _timerOutReset;

    private bool hackbool =false;
    #region unityCalls

    void Start()
    {
        _timerOutReset = this.GetComponent<TimerClock>();
        TimerControllerManager.AddTimer(this.gameObject, _timerOutReset);
       
        _timerOutReset.SetupTimer(120f);
        _timerOutReset.TimerEnded += ResetBackToTitle;
        _timerOutReset.TimerRemoved += CleanUp;
        SetupTitle();
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        Debug.Log(_timerOutReset.TimeCount);
        if ((Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0))
        {
            _timerOutReset.AddTime(0.020f);
        }
    }

    #endregion

    #region  Public 
    public void PlayGame()
    {
        TimerControllerManager.ClearAllTimers();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        TimerControllerManager.ClearAllTimers();
        Application.Quit();
    }
    #endregion

    #region private


    private void ResetBackToTitle()
    {
       
        Debug.Log("reset");
        _timerOutReset.ResetTimer();
        _timerOutReset.ResumeTimer();

        SetupTitle();
    }

    private void CleanUp()
    {
        _timerOutReset.TimerEnded -= ResetBackToTitle;
        _timerOutReset.TimerRemoved -= CleanUp;
    }

    private void SetupTitle()
    {
        _FrontScreen.SetActive(true);
        _Menu.SetActive(false);
        _Credit.SetActive(false);
    }
  
    #endregion

}
