using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace edu_file_viewer
{
    public abstract class FileTreeParser
    {
        public abstract FileTreeNode Parse();

        protected void AddNode(FileTreeNode parent, List<string> path)
        {
            var node = parent.GetChild(path.First());

            if (path.Count() > 1)
            {
                AddNode(node, path.Skip(1).ToList());
            }
        }
    }
}
