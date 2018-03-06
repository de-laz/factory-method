// Copyright (c) de-laz. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace FactoryMethod
{
    using System;

    public class CreatorNotFoundException : Exception
    {
        public CreatorNotFoundException(string message)
            : base(message) {}
    }
}