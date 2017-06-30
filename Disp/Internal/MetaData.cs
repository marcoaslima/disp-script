using Disp.ParsingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disp.Internal
{
    public class MetaData
    {
        public DispFile df;

        public DClass CurrentClass;
        public DFunction CurrentFunction;


        public Boolean WeAreInComments = false;
        public Boolean WeAreInFunction = false;
        
        public MetaData(DispFile df)
        {
            this.df = df;
        }

        public Boolean VerifyExtraCommand(String Command)
        {
            Boolean ToReturn = false;

            if (Command.StartsWith(_Constants.COMMENT_LINE_CHAR))
            {
                ToReturn = true;
            }
            else if (Command.StartsWith(_Constants.COMMENT_BLOCK_OPEN_CHAR))
            {
                WeAreInComments = true;
                ToReturn = true;
            }
            else if (Command.StartsWith(_Constants.COMMENT_BLOCK_CLOSE_CHAR))
            {
                WeAreInComments = false;
                ToReturn = true;
            }
            else if (Command.StartsWith(_Constants.PROGRAM_META))
            {

                ToReturn = true;
            }
            else if (Command.StartsWith(_Constants.START_CLASS))
            {
                String ClassName = Command.Split(' ')[1].TrimEnd().TrimStart();
                DClass cls = new DClass(ClassName);
                this.CurrentClass = cls;

                ToReturn = true;
            }
            else if (Command.StartsWith(_Constants.START_FUNCTION))
            {
                String FunctionName = Command.Split(' ')[1].TrimEnd().TrimStart();

                DFunction cls = new DFunction(FunctionName);
                this.CurrentFunction = cls;

                ToReturn = true;

                WeAreInFunction = true;

            }
            else if (Command.StartsWith(_Constants.END_FUNCTION))
            {
                this.CurrentClass.Functions.Add(this.CurrentFunction);
                WeAreInFunction = false;
            }
            else if (Command.StartsWith(_Constants.END_CLASS))
            {
                this.df.Ambiente.userClasses.Add(this.CurrentClass);
            }


            if (WeAreInComments)
            {
                return WeAreInComments;
            }

            if (WeAreInFunction)
            {
                this.CurrentFunction.FunctionLines.Add(Command);
                return WeAreInComments;
            }

            return ToReturn;
        }
    }
}
