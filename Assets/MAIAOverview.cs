﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CRI.HelloHouston.Experience.MAIA
{
    public class MAIAOverview : MonoBehaviour
    {
        /// <summary>
        /// Script for the whole top screen.
        /// </summary>
        [SerializeField]
        private MAIATopScreen _maiaTopScreen;
        /// <summary>
        /// Long error string to be displayed in a scrolling manner.
        /// </summary>
        [SerializeField]
        private string _scrollingText;
        /// <summary>
        /// Text that displays the scrolling error.
        /// </summary>
        [SerializeField]
        private Text _scrollError;
        /// <summary>
        /// Errors popup on the overview panel.
        /// </summary>
        [SerializeField]
        private GameObject _popupCrash, _popupErrorMessage, _popupInfoMessage;

        //TO DO: find better way of changing panel
        /// <summary>
        /// Displays the manual override screen when the start button is pressed.
        /// </summary>
        public void ManualOverride()
        {
            //TODO: rewrite
            /*_maiaLoadingScreen.SetActive(false);
            _maiaOverviewScreen.SetActive(true);
            _currentPanel = _maiaOverviewScreen;*/
            _popupErrorMessage.SetActive(true);
            _popupInfoMessage.SetActive(true);
            //_manager.ManualOverrideActive();
            
        }

        /// <summary>
        /// Displays a long scrolling error.
        /// </summary>
        /// <returns></returns>
        IEnumerator ScrollingError()
        {
            int i = 0;

            while (i < _scrollingText.Length)
            {
                _scrollError.text += _scrollingText[i++];
                yield return new WaitForSeconds(0.0001f);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
