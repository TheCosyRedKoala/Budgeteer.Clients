using MudBlazor;

namespace Budgeteer.Clients.WebApplication.Shared;

public partial class MainLayout
{
    private bool _drawerOpen = false;

    private MudTheme _budgeteerTheme = new()
    {
        ZIndex =
        {
            AppBar = 10
        }
    };

    void ToggleDrawer()
    {
        _drawerOpen = !_drawerOpen;
    }
}