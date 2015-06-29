using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class ExpressionFunction: ISimpleComWrapper
    {
        private readonly Function _function;

        internal ExpressionFunction(Function function)
        {
            if (function == null) throw new ArgumentNullException("function");
            _function = function;
        }

        public object InternalObject
        {
            get { return _function; }
        }

        public string Name
        {
            get { return _function.Name; }
        }

        public string get_Alias(int aliasIndex)
        {
            return _function.Alias[aliasIndex];
        }

        public int NumAliases
        {
            get { return _function.NumAliases; }
        }

        public int NumParameters
        {
            get { return _function.NumParameters; }
        }

        public FunctionGroup Group
        {
            get { return (FunctionGroup)_function.Group; }
        }

        public string Description
        {
            get { return _function.Description; }
        }

        public string Signature
        {
            get { return _function.Signature;  }
        }

        public string GetParameterName(int paramIndex)
        {
            return _function.ParameterName[paramIndex];
        }

        public string GetParameterDescription(int paramIndex)
        {
            return _function.ParameterDescription[paramIndex];
        }

        /// <summary>
        /// Gets the position of the first argument within signature.
        /// </summary>
        public static bool GetFirstArgumentWithinSignature(string signature, out int start, out int end)
        {
            start = signature.IndexOf('(');
            end = signature.IndexOfAny(new[] { ')', ';' });

            if (start == -1 || end == -1)
            {
                return false;
            }

            // we assume there is a a single space around each argument (see PadSignature)
            // therefore it's 2 and not 1
            start += 2;     
            end -= 2;

            return start <= end;
        }

        /// <summary>
        /// Adds spaces around arguments so they can be selected by double click.
        /// </summary>
        public static string PadSignature(string signature)
        {
            signature = signature.Replace(" ", "");
            signature = signature.Replace("(", "( ");
            signature = signature.Replace(")", " )");
            return signature.Replace(";", " ; ");
        }
    }
}
