#region Usings declarations

using System.Text;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_08._3 {

    public sealed class CallGraph {

        #region Fields declarations

        private readonly List<NodeName> _nodes = new();
        private readonly List<Edge>     _edges = new();

        #endregion

        public void AddEdge(NodeName source, NodeName target) {
            Edge edge = new(source, target);
            _edges.Add(edge);
        }

        public void AddNode(NodeName nodeName) {
            if (nodeName is null) { throw new ArgumentNullException(nameof(nodeName)); }

            _nodes.Add(nodeName);
        }

        public string ToDot() {
            StringBuilder builder = new();
            builder.AppendLine("digraph G {");
            builder.AppendLine("\trankstep=.25;");
            builder.AppendLine("\tedge [arrowsize=.5];");
            builder.AppendLine("\tnode [shape=circle, fontname=\"ArialNarrow\", fontsize=12, fixedsize=true, height=.45];");
            builder.Append("\t");
            foreach (NodeName node in _nodes) {
                builder.Append(node);
                builder.Append("; ");
            }
            builder.AppendLine();
            foreach (Edge edge in _edges) {
                builder.Append("\t");
                builder.Append(edge.Source);
                builder.Append(" -> ");
                builder.Append(edge.Target);
                builder.AppendLine(";");
            }
            builder.AppendLine("}");

            return builder.ToString();
        }

    }

}