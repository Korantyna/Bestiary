using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace Bestiary.Shared
{
    public class MessageDialogModel : BindableBase, IDialogAware
    {
        private string _title;
        private string _ok;
        private string _message;

        public string Ok
        {
            get { return _ok; }
            private set
            {
                if (value == null) { return; }
                _ok = value;
                RaisePropertyChanged();
            }
        }
        public string Message
        {
            get { return _message; }
            private set
            {
                if (value == null) { return; }
                _message = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand CloseDialogCommand { get; }

        public MessageDialogModel()
        {
            _title = string.Empty;
            _message = string.Empty;
            _ok = "ok";
            CloseDialogCommand = new DelegateCommand(CloseDialog, CanCloseDialog);
        }

        private void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        private void CloseDialog()
        {
            RaiseRequestClose(new DialogResult(ButtonResult.OK));
            OnDialogClosed();
        }


        #region IDialogAware Members

        public string Title
        {
            get { return _title; }
            private set
            {
                if (value == null) { return; }
                _title = value;
                RaisePropertyChanged();
            }
        }

        public event Action<IDialogResult>? RequestClose;

        public void OnDialogOpened(IDialogParameters? parameters)
        {
            if (parameters == null) { return; }

            if (parameters.TryGetValue("title", out _title))
            {
                RaisePropertyChanged(nameof(Title));
            }

            if (parameters.TryGetValue("message", out _message))
            {
                RaisePropertyChanged(nameof(Message));
            }

            if (parameters.TryGetValue("ok", out _ok))
            {
                RaisePropertyChanged(nameof(Ok));
            }
        }
        public bool CanCloseDialog() => true;
        public void OnDialogClosed() { }

        #endregion
    }
}