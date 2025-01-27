// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable


namespace Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

/// <summary>
/// Extension methods for <see cref="IModelValidatorProvider"/>.
/// </summary>
public static class ModelValidatorProviderExtensions
{
    /// <summary>
    /// Removes all model validator providers of the specified type.
    /// </summary>
    /// <param name="list">This list of <see cref="IModelValidatorProvider"/>s.</param>
    /// <typeparam name="TModelValidatorProvider">The type to remove.</typeparam>
    public static void RemoveType<TModelValidatorProvider>(this IList<IModelValidatorProvider> list) where TModelValidatorProvider : IModelValidatorProvider
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        RemoveType(list, typeof(TModelValidatorProvider));
    }

    /// <summary>
    /// Removes all model validator providers of the specified type.
    /// </summary>
    /// <param name="list">This list of <see cref="IModelValidatorProvider"/>s.</param>
    /// <param name="type">The type to remove.</param>
    public static void RemoveType(this IList<IModelValidatorProvider> list, Type type)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        for (var i = list.Count - 1; i >= 0; i--)
        {
            var modelValidatorProvider = list[i];
            if (modelValidatorProvider.GetType() == type)
            {
                list.RemoveAt(i);
            }
        }
    }
}
