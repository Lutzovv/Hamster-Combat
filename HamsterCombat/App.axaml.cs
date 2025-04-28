using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using HamsterCombat.Database;
using HamsterCombat.ViewModels;
using HamsterCombat.Views;
using Splat;

namespace HamsterCombat;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void RegisterServices()
    {
        // Регистрация сервисов DI
        Locator.CurrentMutable.Register(() => new DatabaseService(), typeof(IDatabaseService));

        base.RegisterServices();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var dbService = Locator.Current.GetService<IDatabaseService>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(ref dbService)
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel(ref dbService)
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

}