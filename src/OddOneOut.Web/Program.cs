namespace OddOneOut;

/// <summary />
public class Program
{
    /// <summary />
    public static int Main( params string[] args )
    {
        /*
         * 
         */
        var builder = WebApplication.CreateBuilder( args );

        builder.Services.AddRazorPages();
        builder.Services.AddControllers();


        /*
         * 
         */
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if ( !app.Environment.IsDevelopment() )
            app.UseExceptionHandler( "/Error" );

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();
        app.MapControllers();

        app.UseWebSockets( new WebSocketOptions()
        {
            AllowedOrigins = { "https://localhost:5051" }
        } );


        /*
         * 
         */
        app.Run();


        /*
         * 
         */
        return 0;
    }
}