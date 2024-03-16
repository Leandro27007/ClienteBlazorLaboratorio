using Microsoft.JSInterop;

namespace LaboratorioBlazorUI.Helpers
{
    public static class IJSExtensions
    {
        public static async Task<object> GuardarComo(this IJSRuntime js, string nombreArchivo, byte[] archivo)
        {
            return  js.InvokeAsync<object>("saveAsFile", nombreArchivo, Convert.ToBase64String(archivo));
        }
        public async static Task SetInLocalStorage(this IJSRuntime js, string key, string content)
        {
            await js.InvokeAsync<object>("localStorage.setItem", key, content);
        }

        public static async Task<string> GetFromLocalStorage(this IJSRuntime js, string key)
            => await js.InvokeAsync<string>("localStorage.getItem", key);

        public async static Task RemoveItem(this IJSRuntime js, string key)
        {
            await js.InvokeAsync<object>("localStorage.removeItem", key);
        }
    }
}
