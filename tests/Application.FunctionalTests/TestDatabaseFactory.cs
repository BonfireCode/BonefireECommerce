// <copyright file="TestDatabaseFactory.cs" company="Bonefire Code">
// Copyright (c) Bonefire Code 🔥. All rights reserved.
// </copyright>

namespace BonefireECommerce.Application.FunctionalTests;

public static class TestDatabaseFactory
{
    public static async Task<ITestDatabase> CreateAsync()
    {
        var database = new TestcontainersTestDatabase();

        await database.InitialiseAsync();

        return database;
    }
}
