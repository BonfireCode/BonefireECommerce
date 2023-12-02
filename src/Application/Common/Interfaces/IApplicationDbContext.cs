// <copyright file="IApplicationDbContext.cs" company="Bonefire Code">
// Copyright (c) Bonefire Code 🔥. All rights reserved.
// </copyright>

using BonefireECommerce.Domain.Entities;

namespace BonefireECommerce.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
