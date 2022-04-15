using Prism.Services.Dialogs;
using System;

namespace Bestiary.Shared
{
    public static class DialogServiceExtensions
    {
        public static void ShowMessageDialog(this IDialogService dialogService, string message, string ok = "ok", string title = "")
        {
            if (dialogService == null) { throw new ArgumentNullException(nameof(dialogService)); }

            if (message == null) { throw new ArgumentNullException(nameof(message)); }
            if (string.IsNullOrWhiteSpace(message)) { throw new ArgumentException($"The argument {nameof(message)} cannot be empty or whitespace."); }

            if (ok == null) { throw new ArgumentNullException(nameof(ok)); }
            if (string.IsNullOrWhiteSpace(ok)) { throw new ArgumentException($"The argument {nameof(ok)} cannot be empty or whitespace."); }

            if (title == null) { throw new ArgumentNullException(nameof(title)); }

            dialogService.ShowDialog(nameof(MessageDialog), new MessageDialogParameters(message, ok, title), null);
        }
    }
}
