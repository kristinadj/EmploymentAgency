using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace WebShopApp.UI.Shared
{
    public partial class MainLayout : LayoutComponentBase
    {
        [Inject]
        private NavigationManager Navigation { get; set; }

        protected override void OnInitialized()
        {
        }

        private void OnClickHome(MouseEventArgs e)
        {
            Navigation.NavigateTo("/");
        }
    }
}
