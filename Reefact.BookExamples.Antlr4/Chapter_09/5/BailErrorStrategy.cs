#region Usings declarations

using Antlr4.Runtime;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_09._5 {

    public sealed class BailErrorStrategy : DefaultErrorStrategy {

        /*  Instead of recovering from exception e, rethrow it wrapped
         *  in a generic Exception so it is not caught by the 
         *  rule function catches. Exception e is the "cause" of the
         *  Exception.
         */
        public override void Recover(Parser recognizer, RecognitionException e) {
            throw new Exception(e.Message, e);
        }

        /*  Make sure we don't attempt to recover inline; if the parser
         *  successfully recovers, it won't throw an exception
         */
        public override IToken RecoverInline(Parser recognizer) {
            InputMismatchException inputMismatchException = new(recognizer);

            throw new Exception(inputMismatchException.Message, inputMismatchException);
        }

        /*  Make sure we don't attempt to recover from problems in
         *  subrules.
         */
        public override void Sync(Parser recognizer) { }

    }

}