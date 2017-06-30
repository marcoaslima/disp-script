using Disp.ParsingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Disp.Internal
{
    public class Ambiente
    {
        public string CurrentFolder { get; set; }
        public string LibraryFolder { get; set; }

        public List<Disp.Internal.Variable> userVariables { get; set; }
        public List<DClass> userClasses { get; set; }


        // Conteúdo relacionados a execução, são necessários para que se possa enxergar as classes do sistema
        public Dictionary<string, Dictionary<string, IEnumerable<ParameterInfo>>> _commandLibraries;   
        public List<Type> commandClasses { get; set; }
        public DString DefaultCommandClassName;

        public List<Assembly> assemblies;

        public Ambiente()
        {
            this.userVariables = new List<Variable>();
            this.assemblies = new List<Assembly>();
            this.userClasses = new List<DClass>();

            this.CurrentFolder = AppDomain.CurrentDomain.BaseDirectory;
        }

        public void addAssembly(Assembly assembly)
        {
            this.assemblies.Add(assembly);
        }

        public void AddVariable(Disp.Internal.Variable variable)
        {
            this.userVariables.Add(variable);
        }

        public Boolean VariableExists(Variable Variable)
        {
            foreach (Variable userVariable in userVariables)
            {
                if (userVariable.name.Equals(Variable.name))
                {
                    return true;
                }
            }
            return false;
        }

        internal void SetVariableValue(Variable Variable)
        {
            foreach (Variable userVariable in userVariables)
            {
                if (userVariable.name.Equals(Variable.name))
                {
                    userVariable.value = Variable.value;
                }
            }
        }

        public void AddClass(String Name)
        {
            this.userClasses.Add(new DClass(Name));
        }
    }
}
