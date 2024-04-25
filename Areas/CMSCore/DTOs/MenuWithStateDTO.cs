using MercaditoAli.Areas.CMSCore.Entities;

namespace MercaditoAli.Areas.CMSCore.DTOs
{
    public class MenuWithStateDTO : Menu
    {
        public bool IsSelected { get; set; }
    }
}
