using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu_file_viewer
{
    public class FileTreeNode
    {
        public string Name { get; set; }
        public Dictionary<string, FileTreeNode> Children { get; } = new Dictionary<string, FileTreeNode>();
        
        public bool IsFolder => Children.Any();
        public bool IsFile => !Children.Any();

        //Sort by type (folders before files) and then by name
        public List<FileTreeNode> ChildrenSorted => Children.Values.
            OrderBy(c => c.IsFile).
            ThenBy(c => c.Name).
            ToList();        
        
        /// <summary>
        /// Fetch a child by name, create one if it doesn't exist.
        /// </summary>
        /// <param name="name">Name of child</param>
        /// 
        public FileTreeNode GetChild(string name)
        {
            if(Children.TryGetValue(name, out var node))
            {
                return node;
            }

            var newNode = new FileTreeNode() { Name = name };
            Children.Add(name, newNode);
            return newNode;
        }

    }
}
