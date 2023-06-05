using Append.Blazor.Sidepanel;
using Microsoft.AspNetCore.Components;
using TCRK.Models.Budgeteer.Budgets;

namespace Budgeteer.Clients.WebApplication.Pages.Budgets.Components;

public partial class IndexActions
{
    [Inject] public IBudgetService BudgetService { get; set; } = default!;
    [Inject] public ISidepanelService Sidepanel { get; set; } = default!;

    [Parameter, EditorRequired] public EventCallback GetBudgetsAsync { get; set; }

    private void OpenBudgetCreationForm()
    {
        Dictionary<string, object> parameters = new()
        {
            {
                nameof(GetBudgetsAsync),
                GetBudgetsAsync
            }
        };

        Sidepanel.Open<BudgetForm>("Create new budget", null, parameters, BackdropType.LightDismiss);
    }
}