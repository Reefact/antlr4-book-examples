#region Usings declarations

using System.Diagnostics;
using System.Text;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

#endregion

// ReSharper disable once CheckNamespace
namespace Reefact.BookExamples.Antlr4 {

    public sealed class MermaidStyleTreeBuilder : IParseTreeListener {

        #region Statics members declarations

        private static string Escape(string value) {
            string escapedValue = value.Replace("\\", "#0092;")
                                       .Replace("\r", "#0092;r")
                                       .Replace("\n", "#0092;n")
                                       .Replace("<", "#0060;")
                                       .Replace(">", "#0062;")
                                       .Replace("\"", "#0034;");

            return escapedValue;
        }

        #endregion

        #region Fields declarations

        private readonly Parser          _parser;
        private readonly bool            _addClassDef;
        private readonly StringBuilder   _graphBuilder      = new();
        private readonly Stack<NodeInfo> _nodeInfos         = new();
        private readonly HashSet<int>    _nodesAlreadySetup = new();

        private int _nextId = 1;

        #endregion

        #region Constructors declarations

        public MermaidStyleTreeBuilder(Parser parser, bool addClassDef) {
            if (parser is null) { throw new ArgumentNullException(nameof(parser)); }

            _parser      = parser;
            _addClassDef = addClassDef;
            _graphBuilder.AppendLine("graph TD");
        }

        #endregion

        /// <inheritdoc />
        public void VisitTerminal(ITerminalNode node) {
            string       childNodeName  = Escape(node.GetText());
            NodeInfo     childNodeInfo  = new(_nextId++, childNodeName);
            NodeInfo     parentNodeInfo = _nodeInfos.Peek();
            RelationShip relationShip   = new(parentNodeInfo, childNodeInfo);
            WriteRelationship(relationShip);
        }

        /// <inheritdoc />
        public void VisitErrorNode(IErrorNode node) {
            string       childNodeName  = Escape(node.GetText());
            NodeInfo     childNodeInfo  = new(_nextId++, childNodeName);
            NodeInfo     parentNodeInfo = _nodeInfos.Peek();
            RelationShip relationShip   = new(parentNodeInfo, childNodeInfo);
            WriteRelationship(relationShip);
        }

        /// <inheritdoc />
        public void EnterEveryRule(ParserRuleContext ctx) {
            string   ruleName = Escape(_parser.RuleNames[ctx.RuleIndex]);
            NodeInfo nodeInfo = new(_nextId++, ruleName);
            if (_nodeInfos.TryPeek(out NodeInfo? parentNodeInfo)) {
                RelationShip relationShip = new(parentNodeInfo, nodeInfo);
                WriteRelationship(relationShip);
            }
            _nodeInfos.Push(nodeInfo);
        }

        /// <inheritdoc />
        public void ExitEveryRule(ParserRuleContext ctx) {
            _nodeInfos.Pop();
        }

        public string ToMermaidStyleTree() {
            if (_addClassDef) {
                _graphBuilder.AppendLine();
                _graphBuilder.Append("classDef default fill:#fff,stroke:#000,stroke-width:0.25px;");
            }

            return _graphBuilder.ToString();
        }

        private void WriteRelationship(RelationShip relationShip) {
            if (_nodesAlreadySetup.Contains(relationShip.Parent.Id)) {
                _graphBuilder.Append($"\t{relationShip.Parent.Id}");
            } else {
                string parentName = relationShip.Parent.Name;
                _graphBuilder.Append($"\t{relationShip.Parent.Id}[\"{parentName}\"]");
                _nodesAlreadySetup.Add(relationShip.Parent.Id);
            }
            _graphBuilder.Append(" --> ");
            if (_nodesAlreadySetup.Contains(relationShip.Child.Id)) {
                _graphBuilder.AppendLine(relationShip.Child.Id.ToString());
            } else {
                string childName = relationShip.Child.Name;
                _graphBuilder.AppendLine($"{relationShip.Child.Id}[\"{childName}\"]");
                _nodesAlreadySetup.Add(relationShip.Child.Id);
            }
        }

        #region Nested types declarations

        [DebuggerDisplay("{ToString()}")]
        private sealed class NodeInfo : IEquatable<NodeInfo> {

            public static bool operator ==(NodeInfo? left, NodeInfo? right) {
                return Equals(left, right);
            }

            public static bool operator !=(NodeInfo? left, NodeInfo? right) {
                return !Equals(left, right);
            }

            #region Constructors declarations

            public NodeInfo(int id, string name) {
                Id   = id;
                Name = name;
            }

            #endregion

            public int    Id   { get; }
            public string Name { get; }

            /// <inheritdoc />
            public override string ToString() {
                return $"Id={Id}, Name={Name}";
            }

            /// <inheritdoc />
            public bool Equals(NodeInfo? other) {
                if (ReferenceEquals(null, other)) { return false; }
                if (ReferenceEquals(this, other)) { return true; }

                return Id == other.Id && Name == other.Name;
            }

            /// <inheritdoc />
            public override bool Equals(object? obj) {
                return ReferenceEquals(this, obj) || (obj is NodeInfo other && Equals(other));
            }

            /// <inheritdoc />
            public override int GetHashCode() {
                return HashCode.Combine(Id, Name);
            }

        }

        [DebuggerDisplay("{ToString()}")]
        private sealed class RelationShip : IEquatable<RelationShip> {

            public static bool operator ==(RelationShip? left, RelationShip? right) {
                return Equals(left, right);
            }

            public static bool operator !=(RelationShip? left, RelationShip? right) {
                return !Equals(left, right);
            }

            #region Constructors declarations

            public RelationShip(NodeInfo parent, NodeInfo child) {
                if (parent is null) { throw new ArgumentNullException(nameof(parent)); }
                if (child is null) { throw new ArgumentNullException(nameof(child)); }

                Parent = parent;
                Child  = child;
            }

            #endregion

            public NodeInfo Parent { get; }
            public NodeInfo Child  { get; }

            /// <inheritdoc />
            public override string ToString() {
                return $"{Parent.Id}[\"{Parent.Name}\"] --> {Child.Id}[\"{Child.Name}\"]";
            }

            /// <inheritdoc />
            public bool Equals(RelationShip? other) {
                if (ReferenceEquals(null, other)) { return false; }
                if (ReferenceEquals(this, other)) { return true; }

                return Parent == other.Parent && Child == other.Child;
            }

            /// <inheritdoc />
            public override bool Equals(object? obj) {
                return ReferenceEquals(this, obj) || (obj is RelationShip other && Equals(other));
            }

            /// <inheritdoc />
            public override int GetHashCode() {
                return HashCode.Combine(Parent.GetHashCode(), Child.GetHashCode());
            }

        }

        #endregion

    }

}