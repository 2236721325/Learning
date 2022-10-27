using Microsoft.CodeAnalysis;
using System;

namespace SourceGenerater
{
    [Generator]
    public class MyGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            context.AddSource("MyClass1", "static void Main(string[] args)\r\n        {\r\n            Console.WriteLine(\"Hello, World!\");\r\n        }");
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
