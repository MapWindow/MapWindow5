using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BL.Utilities
{
    public enum SortOrder
    {

        ASC,

        DSC

    }

    public class GenericComparer : IComparer
    {
        private string _property;

        private SortOrder _order;

        public GenericComparer(string Property, SortOrder Order)
        {

            this._property = Property;

            this._order = Order;

        }



        //Sort

        public int Compare(object obj1, object obj2)
        {

            int returnValue;

            Type type = obj1.GetType();

            PropertyInfo propertie1 = type.GetProperty(_property);



            Type type2 = obj2.GetType();

            PropertyInfo propertie2 = type2.GetProperty(_property);



            object finalObj1 = propertie1.GetValue(obj1, null);

            object finalObj2 = propertie2.GetValue(obj2, null);



            IComparable Ic1 = finalObj1 as IComparable;

            IComparable Ic2 = finalObj2 as IComparable;



            if (_order == SortOrder.ASC)
            {

                returnValue = Ic1.CompareTo(Ic2);

            }

            else
            {

                returnValue = Ic2.CompareTo(Ic1);

            }

            return returnValue;

        }

    }
}
