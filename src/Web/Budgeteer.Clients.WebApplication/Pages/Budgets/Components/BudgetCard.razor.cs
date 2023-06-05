using Append.Blazor.Sidepanel;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using TCRK.Models.Budgeteer.Budgets;

namespace Budgeteer.Clients.WebApplication.Pages.Budgets.Components;

public partial class BudgetCard
{
    [Inject] public IDialogService Dialog { get; set; } = default!;
    [Inject] public IBudgetService BudgetService { get; set; } = default!;
    [Inject] public ISnackbar Snackbar { get; set; } = default!;
    [Inject] public ISidepanelService Sidepanel { get; set; } = default!;

    [Parameter, EditorRequired] public BudgetDto.Index Budget { get; set; } = default!;
    [Parameter, EditorRequired] public EventCallback GetBudgetsAsync { get; set; }

    private void OpenBudgetUpdateForm()
    {
        Dictionary<string, object> parameters = new()
        {
            {
                nameof(GetBudgetsAsync),
                GetBudgetsAsync
            },
            {
                "Model",
                new BudgetDto.Mutate
                {
                    Name = Budget.Name
                }
            },
            {
                "Id",
                Budget.Id
            }
        };

        Sidepanel.Open<BudgetForm>($"Update {Budget.Name} budget", null, parameters, BackdropType.LightDismiss);
    }

    private async Task OpenDeleteDialog()
    {
        IDialogReference dialog = await Dialog.ShowAsync<BudgetDeleteDialog>("Delete budget");
        DialogResult result = await dialog.Result;

        if (!result.Canceled)
        {
            await BudgetService.DeleteByIdAsync(Budget.Id);
            await GetBudgetsAsync.InvokeAsync();
            Snackbar.Add("Budget succesfully deleted", Severity.Success);
        }
    }
}
