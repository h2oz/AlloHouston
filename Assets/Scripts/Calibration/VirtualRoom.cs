﻿using CRI.HelloHouston.Calibration.XML;
using System.Linq;
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
        /// Init a VirtualRoom
        /// </summary>
        /// <param name="room">A Room Entry</param>
        /// <param name="calibrationManager">The calibration manager</param>
        public void Init(RoomEntry room)
        {
            this.index = room.index;
            this.lastUpdate = room.date;
            if (virtualPositionTags.Length == 0)
                calibrated = true;
            if (room.points.Length >= 3)
                Calibrate(room.points);
        }

        /// <summary>
        /// Get all the zones of a type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public VirtualZone[] GetZones(VirtualZoneType type)
        {
            return blocks.SelectMany(x => x.GetZones(type)).ToArray();
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
                calibrated ? virtualPositionTags : new PositionTag[0],
                lastUpdate
                );
        }
    }
}
