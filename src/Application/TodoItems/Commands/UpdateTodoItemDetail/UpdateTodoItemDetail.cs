﻿// <copyright file="UpdateTodoItemDetail.cs" company="Bonefire Code">
// Copyright (c) Bonefire Code 🔥. All rights reserved.
// </copyright>

using BonefireECommerce.Application.Common.Interfaces;
using BonefireECommerce.Domain.Enums;

namespace BonefireECommerce.Application.TodoItems.Commands.UpdateTodoItemDetail;
public record UpdateTodoItemDetailCommand : IRequest
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public PriorityLevel Priority { get; init; }

    public string? Note { get; init; }
}

public class UpdateTodoItemDetailCommandHandler : IRequestHandler<UpdateTodoItemDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTodoItemDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateTodoItemDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.ListId = request.ListId;
        entity.Priority = request.Priority;
        entity.Note = request.Note;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
