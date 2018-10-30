﻿using CRI.HelloHouston.Calibration.XML;
using System;
using System.Linq;
using UnityEngine;
using VRCalibrationTool;

namespace CRI.HelloHouston.Calibration
{
    public class VirtualRoom : VirtualItem
    {
        /// <summary>
        /// Type of the virtual item.
        /// </summary>
        public override VirtualItemType virtualItemType
        {
            get
            {
                return VirtualItemType.Room;
            }
        }
        /// <summary>
        /// The block of the room.
        /// </summary>
        public VirtualBlock[] blocks;
        /// <summary>
        /// The block table.
        /// </summary>
        public VirtualBlock table;

        /// <summary>
        /// Init a VirtualRoom
        /// </summary>
        /// <param name="room">A Room Entry</param>
        /// <param name="calibrationManager">The calibration manager</param>
        public void Init(RoomEntry room, CalibrationManager calibrationManager)
        {
            this.index = room.index;
            this.lastUpdate = room.date;
            if (room.points.Length >= 3)
                Calibrate(room.points);
            table = Instantiate(calibrationManager.GetVirtualBlockPrefab(room.table), transform);
            table.Init(room.table);
            blocks = new VirtualBlock[room.blocks.Length];
            for (int i = 0; i < room.blocks.Length; i++)
            {
                blocks[i] = Instantiate(calibrationManager.GetVirtualBlockPrefab(room.blocks[i]), transform);
                blocks[i].Init(room.blocks[i]);
            }
        }

        /// <summary>
        /// Gets the RoomEntry for the Virtual Room.
        /// </summary>
        /// <returns></returns>
        public RoomEntry ToRoomEntry()
        {
            return new RoomEntry(
                index,
                blocks.Select(x => x.ToBlockEntry()).ToArray(),
                table.ToBlockEntry(),
                virtualPositionTags,
                lastUpdate
                );
        }
    }
}
