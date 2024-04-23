using Mercadito.Ali.Areas.CMSCore.Entities;

namespace Mercadito.Ali.Areas.CMSCore.DTOs
{
    public class MenuWithStateDTO : Menu
    {
        public bool IsSelected { get; set; }
    }
}
