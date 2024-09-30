using Common.L2.Application;

namespace Shop.L2.Application.Categories.Remove;

public record RemoveCategoryCommand(long categoryId) : IBaseCommand;