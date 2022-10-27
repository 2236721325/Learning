using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace T4CodeGenerator.T4Templates.DbContexts
{
    public partial class  EFDbContextGenerator
    {
        private readonly List<Type> _modelTypes;
        public EFDbContextGenerator(List<Type> modelTypes)
        {
            _modelTypes = modelTypes;
          
        }
    }
}
