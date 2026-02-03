using finance_manager;

namespace FinanceManager.Models.PurchaseModels;

public static class PurchaseModelMappings
{
    public static Purchase ToEntity(this CreatePurchaseRequest request)
    {
        return new Purchase(request.Date, request.Notes);
    }

    public static RetrievePurchaseResponse ToResponse(this Purchase purchase)
    {
        return new RetrievePurchaseResponse
        {
            Id = purchase.Id,
            Date = purchase.Date,
            Notes = purchase.Notes,
            Total = purchase.Total(),
            ExpenseIds = purchase.Expenses.Select(e => e.Id).ToList()
        };
    }
}
