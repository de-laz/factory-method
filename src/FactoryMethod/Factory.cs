// Copyright (c) de-laz. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace FactoryMethod
{
	using System;
	using System.Linq;
	using System.Reflection;

	internal class Factory : IFactory
	{
		private readonly Assembly _assemblyToScan;
		private const string NO_CREATOR_ERROR_MESSAGE =
			@"There is no creator found for creating an instance of {0} from an instance of {1}";

		internal Factory(Assembly assemblyToScan) =>
			_assemblyToScan = assemblyToScan ?? throw new ArgumentNullException(nameof(assemblyToScan));

		public TDestination Create<TSource, TDestination>(TSource source)
			where TSource : class
			where TDestination : class
		{
			var creator = GetCreator<TSource, TDestination>(source);
			return creator.Create(source);
		}

		private ICreator<TSource, TDestination> GetCreator<TSource, TDestination>(TSource source)
			where TSource : class
			where TDestination : class
		{
			var creatorType = _assemblyToScan.GetTypes()
				.SingleOrDefault(type =>
					typeof(ICreator<TSource, TDestination>).IsAssignableFrom(type));

			if (creatorType is null)
			{
				throw new CreatorNotFoundException(
					string.Format(NO_CREATOR_ERROR_MESSAGE, typeof(TDestination), typeof(TSource)));
			}

			return (ICreator<TSource, TDestination>)Activator.CreateInstance(creatorType);
		}
	}
}