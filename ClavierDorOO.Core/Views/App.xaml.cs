using System.IO;
using System.Windows;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Views;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    
    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        // Dans App.xaml.cs ou ton Seeder
        string currentDir = Directory.GetCurrentDirectory();
        MessageBox.Show($"L'application cherche ici : {currentDir}");
        
        var optionsBuilder = new DbContextOptionsBuilder<ClavierDorDbContext>();
        var connectionString = "server=localhost;user=root;password=;database=clavier_dor_oo_db";    
        optionsBuilder.UseMySql(
                connectionString, 
                ServerVersion.AutoDetect(connectionString)
            );
        using (var context = new ClavierDorDbContext(optionsBuilder.Options)) 
        {
            // 2. Lancer le Seeder
            var seeder = new DatabaseSeederService(context);
            
            try 
            {
                await seeder.SeedAsync();
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
    System.Diagnostics.Debug.WriteLine("ERREUR SQL : " + message);
    
    MessageBox.Show($"Erreur SQL : {message}");
            }
        }
    }
}

