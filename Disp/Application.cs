using Disp.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Disp
{
    public class Application
    {
        public Disp.Internal.Ambiente Ambiente;

        public Application(Disp.Internal.Ambiente Ambiente)
        {
            this.Ambiente = Ambiente;
        }

        public System.String SetMath(System.String VariableName, String Value)
        {
            Variable varia = new Disp.Internal.Variable(VariableName);

            NCalc.Expression e = new NCalc.Expression(Value);
            varia.value = e.Evaluate().ToString();

            if (!this.Ambiente.VariableExists(varia))
            {
                this.Ambiente.AddVariable(varia);
            }            

            return "";
        }

        public String Read(System.String VariableName)
        {
            Variable varia = new Disp.Internal.Variable(VariableName);
            
            varia.value = Console.Read();
            if (!this.Ambiente.VariableExists(varia))
            {
                this.Ambiente.AddVariable(varia);
            }
            else
            {
                this.Ambiente.SetVariableValue(varia);
            }

            return String.Empty;
        }

        public System.String Set(System.String VariableName, String Value)
        {
            Variable varia = new Disp.Internal.Variable(VariableName);
            varia.value = Value;

            if (!this.Ambiente.VariableExists(varia))
            {
                this.Ambiente.AddVariable(varia);
            }

            return "";
        }

        public System.String Declare(System.String VariableName)
        {
            Variable varia = new Disp.Internal.Variable(VariableName);

            if (!this.Ambiente.VariableExists(varia))
            {
                this.Ambiente.AddVariable(varia);
            }

            return "";
        }

        public System.String Wait()
        {
            Console.ReadKey();
            return string.Empty;
        }

        public System.String Import(System.String Library)
        {
            return string.Empty;
        }

        public System.String Version()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }



        public System.String Exit()
        {
           
            return string.Empty;
        }

        public string Print(string text)
        {
            Console.Write(text);
            return text;
        }

        public string Printl(string text)
        {
            Console.WriteLine(string.Format(text));
            return string.Empty;
        }

        public string Clear()
        {
            Console.Clear();
            return string.Empty;
        }

        public string Exec(string script)
        {
            DispFile file = new DispFile(this.Ambiente);
            return file.Open(string.Format("{0}\\{1}", this.Ambiente.CurrentFolder, script));
        }

        public string Compile(string script)
        {
            DispFile file = new DispFile(this.Ambiente);
            return file.Compile(string.Format("{0}\\{1}", this.Ambiente.CurrentFolder, script));
        }

        public string Pause()
        {
            Console.ReadKey();
            return string.Empty;
        }

        public string Beep()
        {
            Console.Beep();
            return string.Empty;
        }

        public string Raise(String text)
        {
            throw new Exception(text);
        }

        public String Show(String Variable)
        {
            foreach (Variable item in this.Ambiente.userVariables)
	        {
                if (item.name.Equals(Variable))
                {
                    return item.value.ToString();
                }
	        }
            return String.Format(_Constants.VARIABLE_NOT_FOUND, Variable);
        }

        public String Dclass(String ClassName)
        {
            this.Ambiente.AddClass(ClassName);
            return string.Empty;
        }

        public String Dfunction(String FunctionName)
        {
            return string.Empty;
        }

        public String endclass()
        {
            return string.Empty;
        }

        public String endfunction()
        {
            return string.Empty;
        }

        public String Call(String ClassName, String FunctionName, params String[] Parameters)
        {
            Disp.ParsingModel.DClass CurrentClass = null;
            Disp.ParsingModel.DFunction CurrentFunction = null;

            foreach (Disp.ParsingModel.DClass Classe in this.Ambiente.userClasses)
            {
                if (Classe.ClassName.Equals(ClassName))
                {
                    CurrentClass = Classe;
                    break;
                }
            }

            foreach (Disp.ParsingModel.DFunction Function in CurrentClass.Functions)
            {
                if (Function.FunctionName.Equals(FunctionName))
                {
                    CurrentFunction = Function;
                    break;
                }
            }

            DispFile df = new DispFile(this.Ambiente);
            MetaData meta = new MetaData(df);

            foreach (String Command in CurrentFunction.FunctionLines)
            {
                df.RunLine(Command, meta , 0);
            }
            return string.Empty;
        }
    }
}
