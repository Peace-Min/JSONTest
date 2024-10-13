using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JSONTest
{
    public class ModelItem : ViewModelBase
    {
        public Min _model;
        public Min Model => _model;

        public string UIId
        {
            get => _model.Id;
            set
            {
                _model.Id = value;
                RaisePropertyChanged(nameof(UIId));
            }
        }

        public PersonItem PersonItem { get; set; }

        private ModelItem() { }
        [JsonConstructor]
        public ModelItem(Min model) 
        { 
            _model = model;
            PersonItem = new PersonItem(model.Person);
        }
    }

    public class PersonItem : ViewModelBase
    {
        private Bim _model;
        public Bim Model => _model;

        public string UIName
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                RaisePropertyChanged(nameof(UIName));
            }
        }
        public double UIAge
        {
            get => _model.Age / 2;
            set
            {
                _model.Age = (int)(value * 2);
                RaisePropertyChanged(nameof(UIAge));
            }
        }
        private PersonItem() { }
        [JsonConstructor]
        public PersonItem(Bim model)
        {
            _model = model;
        }
    }
}
