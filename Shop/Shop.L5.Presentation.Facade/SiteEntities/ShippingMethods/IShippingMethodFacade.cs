using Common.L2.Application;
using Shop.L2.Application.SiteEntities.ShippingMethods.Create;
using Shop.L2.Application.SiteEntities.ShippingMethods.Edit;
using Shop.L4.Query.SiteEntities.DTOs;

namespace Shop.L5.Presentation.Facade.SiteEntities.ShippingMethods;

public interface IShippingMethodFacade
{
    Task<OperationResult> Create(CreateShippingMethodCommand command);
    Task<OperationResult> Edit(EditShippingMethodCommand command);
    Task<OperationResult> Delete(long id);


    Task<ShippingMethodDto?> GetShippingMethodById(long id);
    Task<List<ShippingMethodDto>> GetList();
}