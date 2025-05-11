using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace HamsterCombat.Models;

public class Player : ReactiveObject
{
    //public string? Name { get; set; }
    //public int Balance { get; set; }
    //public int ClickPower { get; set; }

    private string? name_;
    private int balance_;


    public string? Name
    {
        get => name_;
        set => this.RaiseAndSetIfChanged(ref name_, value);
    }


    [Reactive] public int Balance { get; set; }
}
