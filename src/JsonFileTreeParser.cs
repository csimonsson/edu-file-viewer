using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace edu_file_viewer
{
    public class JsonFileTreeParser : FileTreeParser
    {
        private readonly string _file;
        
        public JsonFileTreeParser(string file)
        {
            _file = file;
        }

        public override FileTreeNode Parse()
        {
            //Root gets name from file
            var root = new FileTreeNode {Name = Path.GetFileNameWithoutExtension(_file)};

            if (!File.Exists(_file))
            {
                throw new Exception($"Json data not found: {_file}");
            }

            //Deserialize to list of strings and add them to the root node recursively

            JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(_file)).
                ForEach(f => AddNode(root, f.Split('/').ToList()));

            return root;
        }
    }
}
