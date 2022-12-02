#region Usings declarations

using Reefact.BookExamples.Antlr4.Starter;

#endregion

// reads from user console input
string userInput = Console.ReadLine() ?? string.Empty;

// create an ArrayInit reader
ArrayInitReader reader = ArrayInitReader.Read(userInput);

if (args[0] == "-tree") {
    // print LISP-style tree
    Console.WriteLine(reader.ToListStyleTree());
} else if (args[0] == "-transform") {
    // print input transformed to unicode string
    Console.WriteLine(reader.ToUnicodeString());
} else {
    throw new ArgumentException();
}

Console.ReadLine();