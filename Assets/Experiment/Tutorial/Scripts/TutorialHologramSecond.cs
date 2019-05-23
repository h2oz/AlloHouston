﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The hologram for the tutorial experiment.
/// </summary>
namespace CRI.HelloHouston.Experience.Tutorial
{
    public class TutorialHologramSecond : XPHologramElement
    {
        public TutorialManager tutorialManager { get; private set; }
        /// <summary>
        /// Text that displays the time remaining before failure.
        /// </summary> 
        [SerializeField]
        private TextMesh _uiTimer;
        /// <summary>
        /// Timer until failure.
        /// </summary>
        [SerializeField]
        private float _timer;
        public List<Transform> attaches = new List<Transform>();
        public Transform[] freeAttaches;
        [SerializeField]
        private GameObject _virus;
        public int nbViruses = 0;
        public bool isBuilding = false;
        public Transform point1, point2;
        public Material materialSuccess, materialFail;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine("CountDown");
            GameObject[] attachesArray = GameObject.FindGameObjectsWithTag("CoreAttach");

            foreach (GameObject attach in attachesArray)
            {
                attaches.Add(attach.transform);
            }

            freeAttaches = new Transform[attaches.Count];

            
        }

        /// <summary>
        /// CountDown until failure.
        /// </summary>
        /// <returns>Wait for seconds.</returns>
        IEnumerator CountDown()
        {
            float virusCountDown = 0f;
            while (_timer > 0f)
            {
                yield return new WaitForSeconds(1f);
                _timer--;
                _uiTimer.text = _timer.ToString();
                virusCountDown++;
                if (virusCountDown == 10f)
                {
                    virusCountDown = 5f;
                    //GameObject virus = (GameObject)Instantiate(_virus, gameObject.transform.position, gameObject.transform.rotation);
                    //virus.transform.localScale = gameObject.transform.localScale;
                }
            }
            _uiTimer.text = "Fail";
            tutorialManager.EndMaintenance();
        }

        // Update is called once per frame
        void Update()
        {
            if(isBuilding)
            {
                Instantiate(_virus, gameObject.transform.position, gameObject.transform.rotation);
                isBuilding = false;
            }
        }

        public override void OnShow(int currentStep)
        {
            base.OnActivation();
            gameObject.SetActive(false);
        }

        private void Init(TutorialManager synchronizer)
        {
            tutorialManager = synchronizer;
        }

        public override void OnInit(XPManager manager, int randomSeed)
        {
            base.OnInit(manager, randomSeed);
            Init((TutorialManager)manager);
        }
    }
}