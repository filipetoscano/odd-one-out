using Microsoft.AspNetCore.Mvc;
using OddOneOut.Web.Services;
using System.Net.WebSockets;

namespace OddOneOut.Web.Controllers;

/// <summary />
public class SocketsController : ControllerBase
{
    /// <summary />
    public SocketsController( IHub hub )
    {
    }


    /// <summary />
    [Route( "/api/ws" )]
    public async Task<ActionResult> Get()
    {
        // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/websockets?view=aspnetcore-9.0

        if ( HttpContext.WebSockets.IsWebSocketRequest == false )
            return BadRequest();

        using var ws = await HttpContext.WebSockets.AcceptWebSocketAsync();
        await Talk( ws );

        return Ok();
    }


    /// <summary />
    private async Task Talk( WebSocket webSocket )
    {
        /*
         * 
         */
        var buffer = new byte[ 1024 * 4 ];
        var receiveResult = await webSocket.ReceiveAsync(
            new ArraySegment<byte>( buffer ), CancellationToken.None );

        while ( receiveResult.CloseStatus.HasValue == false )
        {
            await webSocket.SendAsync(
                new ArraySegment<byte>( buffer, 0, receiveResult.Count ),
                receiveResult.MessageType,
                receiveResult.EndOfMessage,
                CancellationToken.None );

            receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>( buffer ), CancellationToken.None );
        }


        /*
         * 
         */
        await webSocket.CloseAsync(
            receiveResult.CloseStatus.Value,
            receiveResult.CloseStatusDescription,
            CancellationToken.None );
    }
}
