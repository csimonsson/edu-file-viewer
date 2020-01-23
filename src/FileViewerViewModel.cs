using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace edu_file_viewer
{
    public class FileViewerViewModel
    {
        public List<FileTreeNode> Root { get; } = new List<FileTreeNode>();
        
        public FileViewerViewModel(FileTreeParser parser)
        {
            //Load nodes using the supplied parser

            try
            {
                Root.Add(parser.Parse());
            }
            catch(Exception e)
            {
                //Adde error node if parsing failed
                Root.Add(new FileTreeNode { Name = $"Error: {e.Message}" });
            }
        }
    }
}