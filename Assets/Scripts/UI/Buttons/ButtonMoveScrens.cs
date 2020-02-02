using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMoveScrens : MonoBehaviour
{
    [SerializeField]
    private GameObject _currentScreen;
    [SerializeField]
    private GameObject _targetScreen;


    #region Public
    public void MoveToTargetScreen()
    {

        _currentScreen.SetActive(false);
        _targetScreen.SetActive(true);

    }
    #endregion
}
