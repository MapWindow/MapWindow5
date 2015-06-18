// -------------------------------------------------------------------------------------------
// <copyright file="LayerElementsCollection.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace MW5.Api.Legend
{
    internal class LayerElementsCollection : IEnumerable<LegendElement>
    {
        private readonly List<LegendElement> _elements = new List<LegendElement>();

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<LegendElement> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_elements).GetEnumerator();
        }

        public void Clear()
        {
            _elements.Clear();
        }

        public LegendElement Add(LayerElementType type, Rectangle rect)
        {
            var el = new LegendElement(type, rect);
            _elements.Add(el);
            return el;
        }

        public LegendElement Add(LayerElementType type, Rectangle rect, int index)
        {
            var el = new LegendElement(type, rect, index);
            _elements.Add(el);
            return el;
        }
    }
}