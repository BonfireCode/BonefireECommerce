// <copyright file="UnsupportedColourException.cs" company="Bonefire Code">
// Copyright (c) Bonefire Code 🔥. All rights reserved.
// </copyright>

namespace BonefireECommerce.Domain.Exceptions;

public class UnsupportedColourException : Exception
{
    public UnsupportedColourException(string code)
        : base($"Colour \"{code}\" is unsupported.")
    {
    }
}
