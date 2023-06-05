using Microsoft.AspNetCore.Components;
using TCRK.Models.Budgeteer.Budgets;

namespace Budgeteer.Clients.WebApplication.Pages.Budgets;

public partial class Index
{
    [Inject] public IBudgetService BudgetService { get; set; } = default!;

    private List<BudgetDto.Index>? _budgets;

    protected override async Task OnInitializedAsync()
    {
        await GetBudgetsAsync();
    }

    private async Task GetBudgetsAsync()
    {
        _budgets = await BudgetService.GetIndexAsync();
    }
}