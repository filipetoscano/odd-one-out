using Microsoft.AspNetCore.Mvc.RazorPages;
using QRCoder;
using SixLabors.ImageSharp;

namespace OddOneOut.Web.Pages;

/// <summary />
public class GameModel : PageModel
{
    /// <summary />
    public string? Link { get; set; }

    /// <summary />
    public string? Qrcode { get; set; }


    /// <summary />
    public void OnGet( string id )
    {
        this.Link = "http://localhost:5001/game/" + id;


        /*
         * 
         */
        QRCodeData data;
        
        using ( QRCodeGenerator qrGenerator = new QRCodeGenerator() )
        {
            data = qrGenerator.CreateQrCode( this.Link, QRCodeGenerator.ECCLevel.Q );
        }

        var imgType = Base64QRCode.ImageType.Png;
        var qrCode = new Base64QRCode( data );
        
        this.Qrcode = qrCode.GetGraphic( 20, Color.Black, Color.White, true, imgType );
    }
}