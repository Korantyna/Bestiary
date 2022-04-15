using Bestiary.DataAccess;
using Bestiary.Domain;
using Bestiary.Shared;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using Resources = Bestiary.Properties.ViewModels.MonsterDetailsViewModel.MonsterDetailsViewModel;

namespace Bestiary.ViewModels
{
    public class MonsterDetailsViewModel : BindableBase
    {
        private readonly IBestiary _bestiary;
        private readonly IEventAggregator _eventAggregator;
        private readonly IDialogService _dialogService;

        private bool _isBusy;
        private Monster? _monster;

        public bool IsBusy
        {
            get { return _isBusy; }
            set 
            { 
                _isBusy = value;
                RaisePropertyChanged();
            }
        }
        public Monster? Monster
        {
            get { return _monster; }
            set
            {
                _monster = value;
                RaisePropertyChanged();
            }
        }

        public MonsterDetailsViewModel(IBestiary bestiary, IEventAggregator eventAggregator, IDialogService dialogService)
        {
            _bestiary = bestiary ?? throw new ArgumentNullException(nameof(bestiary));
            _eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

            _eventAggregator.GetEvent<MonsterSelectedEvent<BestiaryReference?>>().Subscribe(b => OnMonsterSelected(b));
        }

        private async void OnMonsterSelected(BestiaryReference? bestiaryReference)
        {
            if (bestiaryReference == null) { Monster = null; }
            else
            {
                try 
                {
                    IsBusy = true;
                    Monster = await _bestiary.FirstOrDefaultAsync(bestiaryReference); 
                }
                catch (Exception ex) 
                { 
                    _dialogService.ShowMessageDialog(ex.Message, Resources.MessageBox_Ok, Resources.MessageBox_ErrorTitle); 
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }
    }
}