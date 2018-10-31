﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace VRCalibrationTool
{
    public class MouseManager : MonoBehaviour
    {
        public static MouseManager instance;

        [SerializeField]
        private PositionTag _mousePositionTag;

        public static int positionTagIndex = 0;

        private List<PositionTag> _mousePositionTagList = new List<PositionTag>();

        public PositionTag[] mousePositionTags
        {
            get
            {
                return _mousePositionTagList.OrderBy(x => x.index).ToArray();
            }
        }

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }

        /// <summary>
        /// Creates a position tag at the given position
        /// </summary>
        /// <param name="position">Position.</param>
        public void CreatePositionTag(Vector3 position)
        {
            Debug.Log(position);
            var mpt = GameObject.Instantiate(_mousePositionTag, position, Quaternion.identity, this.transform);
            mpt.index = positionTagIndex;
            positionTagIndex++;
            _mousePositionTagList.Add(mpt);
        }

        public void ResetPositionTags()
        {
            foreach (var mousePositionTag in _mousePositionTagList)
            {
                Destroy(mousePositionTag.gameObject);
            }
            _mousePositionTagList.Clear();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = Input.mousePosition;
                mousePosition.z = 10.0f;
                CreatePositionTag(Camera.main.ScreenToWorldPoint(mousePosition));
            }
        }
    }
}
