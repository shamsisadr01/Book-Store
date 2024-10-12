﻿using Common.L4.Query;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Shop.L1.Domain.Seller_Aggregate.Enums;
using Shop.L3.Infrastructure.Persistent.Dapper;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Categories;
using Shop.L4.Query.Categories.DTOs;
using Shop.L4.Query.Products.DTOs;

namespace Shop.L4.Query.Products.GetForShop;

internal class GetProductsForShopQueryHandler : IQueryHandler<GetProductsForShopQuery, ProductShopResult>
{
	private readonly DapperContext _dapperContext;
	private readonly StoreContext _context;
	public GetProductsForShopQueryHandler(DapperContext dapperContext, StoreContext context)
	{
		_dapperContext = dapperContext;
		_context = context;
	}

	public async Task<ProductShopResult> Handle(GetProductsForShopQuery request, CancellationToken cancellationToken)
	{
		var @params = request.FilterParams;
		string conditions = "";
		string orderBy = "";
		string inventoryOrderBy = "i.Price Asc";
		CategoryDto? selectedCategory = null;
		if (!string.IsNullOrWhiteSpace(@params.CategorySlug))
		{
			var category = await _context.Categories.FirstOrDefaultAsync(f => f.Slug == @params.CategorySlug, cancellationToken);

			if (category != null)
			{
				conditions += @$" and (A.CategoryId={category.Id} or A.SubCategoryId={category.Id}
                              or A.SecondarySubCategoryId={category.Id})";
				selectedCategory = category.Map();
			}
		}

		if (!string.IsNullOrWhiteSpace(@params.Search))
		{
			conditions += $" and A.Title Like N'%{@params.Search}%'";
		}

		if (@params.OnlyAvailableProducts)
		{
			conditions += " and A.Count>=1";
		}

		if (@params.JustHasDiscount)
		{
			conditions += " and A.DiscountPercentage>0";
			inventoryOrderBy = "i.DiscountPercentage Desc";
		}
		switch (@params.SearchOrderBy)
		{
			case ProductSearchOrderBy.Cheapest:
			{
				orderBy = "A.Price Asc";
				break;
			}
			case ProductSearchOrderBy.Expensive:
			{
				orderBy = "A.Price Desc";
				break;
			}
			case ProductSearchOrderBy.Latest:
			{
				orderBy = "A.Id Desc";
				break;
			}
			default:
				orderBy = "p.Id";
				break;
		}
		using var sqlConnection = _dapperContext.CreateConnection;

		var skip = (@params.PageId - 1) * @params.Take;
		var sql = @$"SELECT Count(A.Title)
            FROM (Select p.Title , i.Price  , i.Id as InventoryId , i.DiscountPercentage , i.Count,
                        p.CategoryId,p.SubCategoryId,p.SecondarySubCategoryId, p.Id as Id , s.Status
                            ,ROW_NUMBER() OVER(PARTITION BY p.Id ORDER BY {inventoryOrderBy} ) AS RN
            From {_dapperContext.Products} p
            left join {_dapperContext.Inventories} i on p.Id=i.ProductId
            left join {_dapperContext.Sellers} s on i.SellerId=s.Id)A
            WHERE  A.RN = 1 and A.Status=@status  {conditions}";


		var resultSql = @$"SELECT A.Slug,A.Id ,A.Title,A.Price,A.InventoryId,A.DiscountPercentage,A.ImageName
            FROM (Select p.Title , i.Price  , i.Id as InventoryId , i.DiscountPercentage,p.ImageName , i.Count,
                        p.CategoryId,p.SubCategoryId,p.SecondarySubCategoryId, p.Slug , p.Id as Id , s.Status
                            ,ROW_NUMBER() OVER(PARTITION BY p.Id ORDER BY {inventoryOrderBy}) AS RN
            From {_dapperContext.Products} p
            left join {_dapperContext.Inventories} i on p.Id=i.ProductId
            left join {_dapperContext.Sellers} s on i.SellerId=s.Id) A
            WHERE  A.RN = 1 and A.Status=@status  {conditions} order By {orderBy} offset @skip ROWS FETCH NEXT @take ROWS ONLY";

		var count = await sqlConnection.QueryFirstAsync<int>(sql, new { status = SellerStatus.Accepted });

		var result = await sqlConnection.QueryAsync<ProductShopDto>(resultSql,
			new { skip, take = @params.Take, status = SellerStatus.Accepted });
		var model = new ProductShopResult()
		{
			FilterParams = @params,
			Data = result.ToList(),
			CategoryDto = selectedCategory
		};
		model.GeneratePaging(count, @params.Take, @params.PageId);
		return model;
	}
}