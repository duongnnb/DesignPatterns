// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Collections.Generic;

namespace Coding.Exercise
{

    public class CodeBuilder
    {

        // TODO
        public class PropertyElement
        {

            public string Name, Type;

            public PropertyElement(string name, string type)
            {
                Name = name;
                Type = type;
            }
            public override string ToString()
            {
                return $"  public {Type} {Name};\n";
            }
        }

        public string className;
        public List<PropertyElement> pros = new List<PropertyElement>();


        public CodeBuilder(string className)
        {
            this.className = className;
        }

        public CodeBuilder AddField(string propertyName, string type)
        {
            var p = new PropertyElement(propertyName, type);
            pros.Add(p);
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"public class {className}\n");
            sb.Append("{\n");
           
            foreach(var p in pros)
            {
                sb.Append(p.ToString());
            }

            sb.Append("}\n");

            return sb.ToString();
        }
    }



    public class Demo
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }
}
