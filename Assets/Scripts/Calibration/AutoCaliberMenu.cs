﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using CRI.HelloHouston.Calibration.XML;

namespace CRI.HelloHouston.Calibration
{
    /// <summary>
    /// Takes the coordonnates of the selected object stored in the XML to auto calibrate it.
    /// </summary>
    public class AutoCaliberMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject _buttonPrefab = null;            //Prefab for the autocalibrate button	
        [SerializeField]
        private GameObject _panelToAttachButtonsTo = null;	//Panel to attach the autocalibrate button to

        private CalibrationManager _viveControllerManager = null;

        private void Start()
        {
            for (int i = 0; i < XMLManager.instance.blockDB.list.Count; i++)
            {
                CreateButton(XMLManager.instance.blockDB.list[i]);
            }
            _viveControllerManager = GameObject.Find("ViveManager").GetComponent<CalibrationManager>();
        }

        /// <summary>
        /// If button clicked, autocalibrates the selected object.
        /// </summary>
        private void OnClick(int blockIndex, BlockType blockType)
        {
            BlockEntry block = XMLManager.instance.blockDB.list.FirstOrDefault(x => x.type == blockType);
            if (block != null)
            {
                _viveControllerManager.ResetPositionTags();
                _viveControllerManager.CreatePositionTag(block.serializablePoints.Length);
                for (int i = 0; i < block.serializablePoints.Length; i++)
                {
                    _viveControllerManager._positionTags[i].transform.position = block.serializablePoints[i].Vector3;
                }
                _viveControllerManager.CalibrateVR(blockIndex, blockType);
            }
        }

        /// <summary>
        /// Creates an autocalibrate button.
        /// </summary>
        /// <param name="name">Name.</param>
        private void CreateButton(BlockEntry block)
        {
            GameObject button = (GameObject)Instantiate(_buttonPrefab);
            button.transform.SetParent(_panelToAttachButtonsTo.transform);
            button.GetComponent<Button>().onClick.AddListener(() => OnClick(block.index, block.type));
            button.transform.GetChild(0).GetComponent<Text>().text = block.type.ToString();
        }
    }
}