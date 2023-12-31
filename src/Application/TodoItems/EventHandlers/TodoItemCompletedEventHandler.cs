﻿// <copyright file="TodoItemCompletedEventHandler.cs" company="Bonefire Code">
// Copyright (c) Bonefire Code 🔥. All rights reserved.
// </copyright>

using BonefireECommerce.Domain.Events;
using Microsoft.Extensions.Logging;

namespace BonefireECommerce.Application.TodoItems.EventHandlers;
public class TodoItemCompletedEventHandler : INotificationHandler<TodoItemCompletedEvent>
{
    private readonly ILogger<TodoItemCompletedEventHandler> _logger;

    public TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("BonefireECommerce Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
