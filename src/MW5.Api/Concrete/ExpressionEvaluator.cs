using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Api.Helpers;
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

        public bool ParseForTable(string expr, IAttributeTable table)
        {
            return _expression.ParseForTable(expr, table.GetInternal());
        }

        public bool CalculateForTableRow(int RowIndex, int targetFieldIndex)
        {
            return _expression.CalculateForTableRow(RowIndex, targetFieldIndex);
        }

        public bool CalculateForTableRow2(int RowIndex, out object result)
        {
            return _expression.CalculateForTableRow2(RowIndex, out result);
        }

        public bool Calculate(out object result)
        {
            return _expression.Calculate(out result);
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

        public ExpressionFunction get_SupportedFunction(int functionIndex)
        {
            return new ExpressionFunction(_expression.SupportedFunction[functionIndex]);
        }

        public IAttributeTable Table
        {
            get
            {
                var table = _expression.Table;
                return table != null ? new AttributeTable(table) : null;
            }
        }

        public IEnumerator<ExpressionFunction> GetEnumerator()
        {
            for (var i = 0; i < NumSupportedFunctions; i++)
            {
                var fn = get_SupportedFunction(i);
                if (fn != null)
                {
                    yield return fn;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
