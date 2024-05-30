using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Fina.Web.Pages.Categories
{
    public partial class GetAllCategoriesPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;

        public List<Category> Categories { get; set; } = [];
        #endregion

        #region Services
        [Inject]
        public ICategoryHandler Handler { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;
        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;

            try
            {
                var request = new GetAllCategoriesRequets();
                var result = await Handler.GetAllAsync(request);

                if (result.IsSuccess)
                    Categories = result.Data ?? [];

            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally { IsBusy = false; }
        }
        #endregion

        #region Methodes
        public async void OnDeleteButtonClickedAsync(long id, string title)
        {
            var result = await Dialog.ShowMessageBox("Atenção",
                $"Ao prosseguir {title} será removida, deseja continuar?",
                yesText: "Excluir", noText: "Cancelar");

            if (result is true)
                await OnDeleteAsync(id, title);

            StateHasChanged();
        }

        public async Task OnDeleteAsync(long id, string title)
        {
            try
            {
                var request = new DeleteCategoryRequest
                {
                    Id = id,
                };

                var response = await Handler.DeleteAsync(request);
                if (response.IsSuccess)
                {
                    Categories.RemoveAll(x => x.Id == id);
                    Snackbar.Add($"Categoria {title} removida com sucesso!", Severity.Success);
                }
                else
                    Snackbar.Add($"Não foi possível remover a categoria {title}!", Severity.Error);

            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally { IsBusy = false; }
        }
        #endregion
    }
}
