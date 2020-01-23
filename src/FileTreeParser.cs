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
        /// <summary>
        /// Parses the data and returns the root of the tree of nodes
        /// </summary>
        /// <returns>Root node</returns>

        public abstract FileTreeNode Parse();


        /// <summary>
        /// Adds a child to this and continues adding recursively if there are more portions in the path
        /// </summary>
        /// <param name="parent">Parent for the added child</param>
        /// <param name="path">List of strings defining the path</param>
        /// 
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
