﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.InlineHints
{
    internal readonly struct TypeHint
    {
        public TypeHint(ITypeSymbol type, TextSpan span, bool leadingSpace = false, bool trailingSpace = false)
            : this(type, span,
                  prefix: CreateSpaceSymbolPartArray(leadingSpace),
                  suffix: CreateSpaceSymbolPartArray(trailingSpace))
        {
        }

        private static ImmutableArray<SymbolDisplayPart> CreateSpaceSymbolPartArray(bool hasSpace)
            => hasSpace
                ? ImmutableArray.Create(new SymbolDisplayPart(SymbolDisplayPartKind.Space, symbol: null, " "))
                : ImmutableArray<SymbolDisplayPart>.Empty;

        private TypeHint(ITypeSymbol type, TextSpan span, ImmutableArray<SymbolDisplayPart> prefix, ImmutableArray<SymbolDisplayPart> suffix)
        {
            Type = type;
            Span = span;
            Prefix = prefix;
            Suffix = suffix;
        }

        public ITypeSymbol Type { get; }
        public TextSpan Span { get; }
        public ImmutableArray<SymbolDisplayPart> Prefix { get; }
        public ImmutableArray<SymbolDisplayPart> Suffix { get; }

        public void Deconstruct(out ITypeSymbol type, out TextSpan span, out ImmutableArray<SymbolDisplayPart> prefix, out ImmutableArray<SymbolDisplayPart> suffix)
        {
            type = Type;
            span = Span;
            prefix = Prefix;
            suffix = Suffix;
        }
    }
}
