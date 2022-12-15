﻿#region Usings declarations

using System.Diagnostics;
using System.Text;

using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4 {

    public sealed class MermaidStyleTreeBuilder : LispStyleTreeBaseListener {

        #region Fields declarations

        private readonly StringBuilder   _graphBuilder      = new();
        private readonly Stack<NodeInfo> _nodeInfos         = new();
        private readonly HashSet<int>    _nodesAlreadySetup = new();

        private int _nextId = 1;

        #endregion

        #region Constructors declarations

        public MermaidStyleTreeBuilder() {
            _graphBuilder.AppendLine("graph TD");
        }

        #endregion

        /// <inheritdoc />
        public override void EnterParent_node(LispStyleTreeParser.Parent_nodeContext context) {
            NodeInfo nodeInfo = new(_nextId++, context.ID().GetText());
            if (_nodeInfos.TryPeek(out NodeInfo? parentNodeInfo)) {
                RelationShip relationShip = new(parentNodeInfo, nodeInfo);
                WriteRelationship(relationShip);
            }
            _nodeInfos.Push(nodeInfo);
        }

        /// <inheritdoc />
        public override void ExitParent_node(LispStyleTreeParser.Parent_nodeContext context) {
            _nodeInfos.Pop();
        }

        /// <inheritdoc />
        public override void EnterChild_node(LispStyleTreeParser.Child_nodeContext context) {
            ITerminalNode node = context.ID();
            if (node == null) { return; }

            string       childNodeName  = node.GetText();
            NodeInfo     childNodeInfo  = new(_nextId++, childNodeName);
            NodeInfo     parentNodeInfo = _nodeInfos.Peek();
            RelationShip relationShip   = new(parentNodeInfo, childNodeInfo);
            WriteRelationship(relationShip);
        }

        /// <inheritdoc />
        public override void VisitTerminal(ITerminalNode node) { }

        /// <inheritdoc />
        public override string ToString() {
            _graphBuilder.AppendLine();
            _graphBuilder.Append("classDef default fill:#fff,stroke:#000,stroke-width:0.25px;");

            return _graphBuilder.ToString();
        }

        private void WriteRelationship(RelationShip relationShip) {
            if (_nodesAlreadySetup.Contains(relationShip.Parent.Id)) {
                _graphBuilder.Append($"\t{relationShip.Parent.Id}");
            } else {
                _graphBuilder.Append($"\t{relationShip.Parent.Id}[\"{relationShip.Parent.Name}\"]");
                bool added = _nodesAlreadySetup.Add(relationShip.Parent.Id);
            }
            _graphBuilder.Append(" --> ");
            if (_nodesAlreadySetup.Contains(relationShip.Child.Id)) {
                _graphBuilder.AppendLine(relationShip.Child.Id.ToString());
            } else {
                _graphBuilder.AppendLine($"{relationShip.Child.Id}[\"{relationShip.Child.Name}\"]");
                bool added = _nodesAlreadySetup.Add(relationShip.Child.Id);
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