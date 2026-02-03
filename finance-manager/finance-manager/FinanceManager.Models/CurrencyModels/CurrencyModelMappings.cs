using finance_manager;

namespace FinanceManager.Models.CurrencyModels;

public static class CurrencyModelMappings
{
    public static Currency ToEntity(this CreateCurrencyRequest request)
    {
        return new Currency(request.Code, request.FullName, request.Symbol);
    }

    public static RetrieveCurrencyResponse ToResponse(this Currency currency)
    {
        return new RetrieveCurrencyResponse
        {
            Id = currency.Id,
            Code = currency.Code,
            FullName = currency.FullName,
            Symbol = currency.Symbol
        };
    }
}
