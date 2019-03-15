﻿using ClashRoyale.Logic;

namespace ClashRoyale.Protocol.Messages.Server
{
    public class OwnHomeDataMessage : PiranhaMessage
    {
        public OwnHomeDataMessage(Device device) : base(device)
        {
            Id = 24101;
            device.CurrentState = Device.State.Home;
        }

        public override void Encode()
        {
            Device.Player.LogicClientHome(Packet);
            Device.Player.LogicClientAvatar(Packet);
        }
    }
}