// -------------------------------------------------------------------------------------------
// <copyright file="LayoutElementCollection.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using MW5.Plugins.Printing.Model.Elements;

namespace MW5.Plugins.Printing.Model
{
    internal class LayoutElementCollection : IEnumerable<LayoutElement>
    {
        private readonly List<LayoutElement> _elements;

        public LayoutElementCollection()
        {
            _elements = new List<LayoutElement>();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        public IEnumerator<LayoutElement> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}