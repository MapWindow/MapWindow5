using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class ExpressionEvaluator: ISimpleComWrapper, IEnumerable<ExpressionFunction>
    {
        private readonly Expression _expression;

        public ExpressionEvaluator()
        {
            _expression = new Expression();
        }

        internal ExpressionEvaluator(Expression expression)
        {
            if (expression == null) throw new ArgumentNullException("expression");

            _expression = expression;
        }

        public object InternalObject
        {
            get { return _expression; }
        }

        public bool Parse(string expr)
        {
            return _expression.Parse(expr);
        }

        public bool Evaluate(out object result)
        {
            return _expression.Evaluate(out result);
        }

        public string LastErrorMessage
        {
            get { return _expression.LastErrorMessage; }
        }

        public int LastErrorPosition
        {
            get { return _expression.LastErrorPosition; }
        }

        public int NumSupportedFunctions
        {
            get { return _expression.NumSupportedFunctions; }
        }

        public Function get_SupportedFunction(int functionIndex)
        {
            return _expression.SupportedFunction[functionIndex];
        }

        public IEnumerator<ExpressionFunction> GetEnumerator()
        {
            for (int i = 0; i < NumSupportedFunctions; i++)
            {
                var fn = get_SupportedFunction(i);
                if (fn != null)
                {
                    yield return new ExpressionFunction(fn);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
