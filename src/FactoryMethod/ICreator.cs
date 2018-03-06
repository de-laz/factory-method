// Copyright (c) de-laz. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace FactoryMethod
{
    public interface ICreator<in TSource, out TDestination>
        where TSource : class
        where TDestination : class
    {
        TDestination Create(TSource source);
    }
}