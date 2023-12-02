﻿// <copyright file="DeleteTodoListTests.cs" company="Bonefire Code">
// Copyright (c) Bonefire Code 🔥. All rights reserved.
// </copyright>

using BonefireECommerce.Application.TodoLists.Commands.CreateTodoList;
using BonefireECommerce.Application.TodoLists.Commands.DeleteTodoList;
using BonefireECommerce.Domain.Entities;

namespace BonefireECommerce.Application.FunctionalTests.TodoLists.Commands;

using static Testing;

public class DeleteTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new DeleteTodoListCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List",
        });

        await SendAsync(new DeleteTodoListCommand(listId));

        var list = await FindAsync<TodoList>(listId);

        list.Should().BeNull();
    }
}
