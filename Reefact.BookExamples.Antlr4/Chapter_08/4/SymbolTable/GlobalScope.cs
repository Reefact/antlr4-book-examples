#region Usings declarations

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._4.SymbolTable {

    public class GlobalScope : BaseScope {

        #region Constructors declarations

        /// <inheritdoc />
        public GlobalScope() : base(null) { }

        #endregion

        public override string Name => "globals";

    }

}