using Bestiary.DataAccess;
using Bestiary.Shared;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using Resources = Bestiary.Properties.ViewModels.MonsterSelectionViewModel.MonsterSelectionViewModel;

namespace Bestiary.ViewModels
{
    public class MonsterSelectionViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IBestiary _bestiary;
        private readonly IDialogService _dialogService;

        private bool _isBusy;
        private BestiaryReference? _monster;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<BestiaryReference> Monsters { get; private set; }
        public BestiaryReference? Monster
        {
            get { return _monster; }
            set 
            { 
                _monster = value;
                _eventAggregator.GetEvent<MonsterSelectedEvent<BestiaryReference?>>().Publish(value);
            }
        }

        public DelegateCommand LoadDataCommand { get; }

        public MonsterSelectionViewModel(IBestiary bestiary, IEventAggregator eventAggregator, IDialogService dialogService)
        {
            _eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
            _bestiary = bestiary ?? throw new ArgumentNullException(nameof(bestiary));
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

            Monsters = new ObservableCollection<BestiaryReference>();

            LoadDataCommand = new DelegateCommand(LoadData);
        }

        public async void LoadData()
        {
            try 
            {
                IsBusy = true;
                Monsters.AddRange(await _bestiary.GetBestiaryReferencesAsync()); 
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