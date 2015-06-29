// -------------------------------------------------------------------------------------------
// <copyright file="RecalculateFieldWrapper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using MW5.Api.Interfaces;

namespace MW5.Plugins.TableEditor.Model
{
    internal class RecalculateFieldWrapper
    {
        private readonly IAttributeField _field;

        public RecalculateFieldWrapper(IAttributeField field)
        {
            if (field == null) throw new ArgumentNullException("field");
            _field = field;

            Selected = true;
            Details = string.Empty;
            Result = RecalculateFieldResult.None;
        }

        public string Expression
        {
            get { return _field.Expression; }
        }

        [Browsable(false)]
        public int Index
        {
            get { return _field.Index; }
        }

        [Browsable(false)]
        public RecalculateFieldResult Result {  get; private set; }
        
        public string Name
        {
            get { return _field.DisplayName; }
        }

        [DisplayName("Result")]
        public string Details { get; private set; }

        [DisplayName(" ")]
        public bool Selected { get; set; }

        public void SetResult(RecalculateFieldResult result, string details)
        {
            Result = result;
            Details = details;
        }

        public void ClearResult()
        {
            Result = RecalculateFieldResult.None;
            Details = string.Empty;
        }
    }
}