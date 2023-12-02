// <copyright file="DeleteTodoItemTests.cs" company="Bonefire Code">
// Copyright (c) Bonefire Code 🔥. All rights reserved.
// </copyright>

using BonefireECommerce.Application.TodoItems.Commands.CreateTodoItem;
using BonefireECommerce.Application.TodoItems.Commands.DeleteTodoItem;
using BonefireECommerce.Application.TodoLists.Commands.CreateTodoList;
using BonefireECommerce.Domain.Entities;

namespace BonefireECommerce.Application.FunctionalTests.TodoItems.Commands;

using static Testing;
public class DeleteTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List",
        });

        var itemId = await SendAsync(new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "New Item",
        });

        await SendAsync(new DeleteTodoItemCommand(itemId));

        var item = await FindAsync<TodoItem>(itemId);

        item.Should().BeNull();
    }
}
