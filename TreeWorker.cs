using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    internal abstract class TreeWorker
    {
        private readonly ITreeBuilder _treeBuilder;

        protected TreeWorker(ITreeBuilder treeBuilder)
        {
            if (treeBuilder == null) 
                throw new ArgumentNullException("treeBuilder");

            _treeBuilder = treeBuilder;
        }

        protected virtual IParseTree CreateTree(ICharStream input, IEnumerable<IAntlrErrorListener<int>> lexerErrorListeners,
            IEnumerable<IAntlrErrorListener<IToken>> errorListeners)
        {
            if (input == null) 
                throw new ArgumentNullException("input");

            var builder = _treeBuilder;
            var tree = builder.CreateTree(input, lexerErrorListeners, errorListeners);

            return tree;
        }
    }
}