// Copyright (c) de-laz. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace FactoryMethod
{
    public interface IFactory
    {
        /// <summary>
		/// Creates an instance of type TDestination from an instance of type TSource. 
		/// </summary>
		/// <typeparam name="TSource">The type of object from which an instance of TDestiation is to be created.</typeparam>
		/// <typeparam name="TDestination">The type of object to be created.</typeparam>
		/// <param name="source"></param>
		/// <exception cref="AssemblyNotFoundException">When the assembly to be scanne is not found.</exception>
		/// <returns>An instance of type TDestination</returns>
        TDestination Create<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class;
    }
}