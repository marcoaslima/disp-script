using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Disp.Internal
{
    public class ConsoleCommand
    {
        public ConsoleCommand(string input)
        {
            // Ugly regex to split string on spaces, but preserve quoted text intact:
            var stringArray =
                Regex.Split(input,
                    "(?<=^[^\"]*(?:\"[^\"]*\"[^\"]*)*) (?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

            _arguments = new List<string>();
            for (int i = 0; i < stringArray.Length; i++)
            {
                // The first element is always the command:
                if (i == 0)
                {
                    this.Name = stringArray[i];

                    // Set the default:
                    this.LibraryClassName = "Application";
                    string[] s = DOut.FirstToCapital(stringArray[0].Split('.'));
                    if (s.Length == 2)
                    {
                        this.LibraryClassName = s[0];
                        this.Name = s[1];
                    }
                    else if (s.Length == 1)
                    {
                        this.Name = s[0];
                    }
                }
                else
                {
                    var inputArgument = stringArray[i];
                    string argument = inputArgument;

                    // Is the argument a quoted text string?
                    var regex = new Regex("\"(.*?)\"", RegexOptions.Singleline);
                    var match = regex.Match(inputArgument);

                    if (match.Captures.Count > 0)
                    {
                        // Get the unquoted text:
                        var captureQuotedText = new Regex("[^\"]*[^\"]");
                        var quoted = captureQuotedText.Match(match.Captures[0].Value);
                        argument = quoted.Captures[0].Value;
                    }
                    _arguments.Add(argument);
                }
            }
        }

        private string _name { get; set; }

        public string Name
        {
            get { return this._name; }
            set { this._name = DOut.Capitalize(value); } 
        }
        public string LibraryClassName { get; set; }

        public List<string> _arguments;
        public IEnumerable<string> Arguments
        {
            get
            {
                return _arguments;
            }
        }
    }
}
