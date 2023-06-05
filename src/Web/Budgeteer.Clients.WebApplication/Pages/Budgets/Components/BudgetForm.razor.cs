using Append.Blazor.Sidepanel;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using TCRK.Models.Budgeteer.Budgets;

namespace Budgeteer.Clients.WebApplication.Pages.Budgets.Components;

public partial class BudgetForm
{
    [Inject] public IBudgetService BudgetService { get; set; } = default!;
    [Inject] public ISidepanelService Sidepanel { get; set; } = default!;
    [Inject] public ISnackbar Snackbar { get; set; } = default!;

    [Parameter] public EventCallback GetBudgetsAsync { get; set; }
    [Parameter] public BudgetDto.Mutate? Model { get; set; }
    [Parameter] public Guid? Id { get; set; }

    private BudgetDto.Mutate _model = new();
    private BudgetDto.Mutate.Validator _budgetValidator = new();
    private MudForm? _form;
    private bool _isUpdate = false;

    protected override void OnInitialized()
    {
        if (Model is not null && Id is not null)
        {
            _model = Model;
            _isUpdate = true;
        }
    }

    private async Task Submit()
    {
        await _form!.Validate();

        if (_form!.IsValid)
        {
            if (!_isUpdate)
            {
                await BudgetService.CreateAsync(_model);
            }
            else
            {
                await BudgetService.UpdateByIdAsync((Guid)Id!, _model);
            }

            Sidepanel.Close();

            await GetBudgetsAsync.InvokeAsync();
            Snackbar.Add("Budget succesfully created", Severity.Success);
        }
    }



    private void Cancel() 
    {
        Sidepanel.Close();
    }
}