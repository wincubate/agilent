using System.Threading.Tasks;

namespace ClientApp.ViewModels
{
    interface ICanSendNotes
    {
        Task SendNoteAsync(int serial, string note);
    }
}
