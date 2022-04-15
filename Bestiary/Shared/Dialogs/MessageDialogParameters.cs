using Prism.Services.Dialogs;
using System;

namespace Bestiary.Shared
{
    public class MessageDialogParameters : DialogParameters
    {
        public MessageDialogParameters(string message, string ok = "ok", string title = "")
        {
            if (message == null) { throw new ArgumentNullException(nameof(message)); }
            if (string.IsNullOrWhiteSpace(message)) { throw new ArgumentException($"The argument {nameof(message)} cannot be empty or whitespace."); }

            if (ok == null) { throw new ArgumentNullException(nameof(ok)); }
            if (string.IsNullOrWhiteSpace(ok)) { throw new ArgumentException($"The argument {nameof(ok)} cannot be empty or whitespace."); }

            if (title == null) { throw new ArgumentNullException(nameof(ok)); }
            if (string.IsNullOrWhiteSpace(title)) { throw new ArgumentException($"The argument {nameof(title)} cannot be empty or whitespace."); }

            Add("message", message);
            Add("ok", ok);
            Add("title", title);
        }
    }
}
