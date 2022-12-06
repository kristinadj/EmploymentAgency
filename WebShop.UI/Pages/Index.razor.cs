using EmploymentAgency.DTO;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace WebShopApp.UI.Pages
{
    public partial class Index
    {
        SignInDTO signInDTO = new SignInDTO();

        protected override void OnInitialized()
        {
        }

        public void Submit(EditContext context)
        {
            Console.WriteLine("Submited");
        }
    }
}
