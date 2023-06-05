using Microsoft.AspNetCore.Components;
using MudBlazor;
using TCRK.Models.Budgeteer.Budgets;

namespace Budgeteer.Clients.WebApplication.Pages.Budgets.Components;

public partial class BudgetDeleteDialog
{
    [Inject] public IBudgetService BudgetService { get; set; } = default!;

    [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = default!;

    private void Cancel()
    {
        MudDialog.Cancel();
    }

    private void Delete()
    {
        MudDialog.Close(DialogResult.Ok(true));
    }
}
