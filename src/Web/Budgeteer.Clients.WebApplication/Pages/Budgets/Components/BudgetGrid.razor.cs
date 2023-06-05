using Microsoft.AspNetCore.Components;
using TCRK.Models.Budgeteer.Budgets;

namespace Budgeteer.Clients.WebApplication.Pages.Budgets.Components;

public partial class BudgetGrid
{
    [Parameter, EditorRequired] public List<BudgetDto.Index> Budgets { get; set; } = default!;
    [Parameter, EditorRequired] public EventCallback GetBudgetsAsync { get; set; } = default!;
}