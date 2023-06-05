using TCRK.Models.Budgeteer.Budgets;

namespace Budgeteer.Clients.WebApplication.Data;

public class BudgetService : IBudgetService
{
    private readonly HttpClient _queryClient;
    private readonly HttpClient _commandClient;
    private const string _endpoint = "api/budget";

    public BudgetService(IHttpClientFactory httpClientFactory)
    {
        _commandClient = httpClientFactory.CreateClient("Budgeteer.Services.CommandApi");
        _queryClient = httpClientFactory.CreateClient("Budgeteer.Services.QueryApi");
    }

    public async Task<Guid> CreateAsync(BudgetDto.Mutate model)
    {
        var response = await _commandClient.PostAsJsonAsync(_endpoint, model);
        return await response.Content.ReadFromJsonAsync<Guid>();
    }

    public async Task<BudgetDto.Detail> GetDetailAsync(Guid id)
    {
        var response = await _queryClient.GetFromJsonAsync<BudgetDto.Detail>($"{_endpoint}/{id}");
        return response!;
    }

    public async Task<List<BudgetDto.Index>> GetIndexAsync()
    {
        var response = await _queryClient.GetFromJsonAsync<List<BudgetDto.Index>>(_endpoint);
        return response!;
    }

    public async Task UpdateByIdAsync(Guid id, BudgetDto.Mutate model)
    {
        await _commandClient.PutAsJsonAsync($"{_endpoint}/{id}", model);
    }

    public Task AddMonthlyBudgetAsync(BudgetRequest.AddMonthlyBudget request)
    {
        throw new NotImplementedException();
    }

    public Task RemoveMonthlyBudgetAsync(BudgetRequest.RemoveMonthlyBudget request)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        await _commandClient.DeleteAsync($"{_endpoint}/{id}");
    }
}
