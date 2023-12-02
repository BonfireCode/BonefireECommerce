// <copyright file="WeatherForecasts.cs" company="Bonefire Code">
// Copyright (c) Bonefire Code 🔥. All rights reserved.
// </copyright>

using BonefireECommerce.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Authorization;

namespace BonefireECommerce.Web.Endpoints;

[AllowAnonymous]
public class WeatherForecasts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetWeatherForecasts);
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts(ISender sender)
    {
        return await sender.Send(new GetWeatherForecastsQuery());
    }
}
