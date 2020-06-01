using System;
using MW5.Api.Concrete;
using MW5.Plugins.Symbology.Properties;

namespace MW5.Plugins.Symbology.Services
{
    public class SymbolRotaterCursor
    {
        private static CustomCursor _cursor;

        public static CustomCursor Instance
        {
            get
            {
                var guid = new Guid("D223FC1C-145C-4ABC-98C6-792C12F4AFF8");
                return _cursor ?? (_cursor = new CustomCursor(guid, Resources.cursor_rotate, 0, 0));
            }
        }
    }
}
