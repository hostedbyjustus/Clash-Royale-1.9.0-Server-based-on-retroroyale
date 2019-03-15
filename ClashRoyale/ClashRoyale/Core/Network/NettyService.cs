﻿using System.Net;
using System.Threading.Tasks;
using ClashRoyale.Core.Network.Handlers;
using DotNetty.Handlers.Logging;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;

namespace ClashRoyale.Core.Network
{
    public class NettyService
    {
        public MultithreadEventLoopGroup BossGroup { get; set; }
        public MultithreadEventLoopGroup WorkerGroup { get; set; }

        public ServerBootstrap ServerBootstrap { get; set; }

        public async Task RunServerAsync()
        {
            BossGroup = new MultithreadEventLoopGroup();
            WorkerGroup = new MultithreadEventLoopGroup();

            ServerBootstrap = new ServerBootstrap();
            ServerBootstrap.Group(BossGroup, WorkerGroup);
            ServerBootstrap.Channel<TcpServerSocketChannel>();

            ServerBootstrap
                .Option(ChannelOption.SoBacklog, 100)
                .Option(ChannelOption.TcpNodelay, true)
                .Handler(new LoggingHandler("SRV-ICR"))
                .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                {
                    var pipeline = channel.Pipeline;
                    pipeline.AddLast("PacketProcessor", new PacketHandler());
                }));

            var boundChannel = await ServerBootstrap.BindAsync(9339);

            Logger.Log($"Listening on {((IPEndPoint) boundChannel.LocalAddress).Port} with DotNetty!", GetType());
        }
    }
}