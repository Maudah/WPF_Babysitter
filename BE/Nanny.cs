using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BE
{
    public class Nanny : INotifyPropertyChanged
    {
        string nannyId;
        string nannyLastName;
        string nannyFirstName;
        string nannyPhone;
        string nannyAddress;
        DateTime nannyBirth;
        bool isElevators;
        int nannyflat;
        int nannyExperience;
        int maxChild;
        int minAge;
        int maxAge;
        bool isHours;
        double moneyForHour;
        double moneyForMonth;
        bool[] days;
        string[][] times;
        bool isTMTVocation;
        string recommendation;
        bool isspecial;
      
        public Nanny()
        {
            days = new bool[6];
            times = new string[6][];
        }
        public string NannyId
        {
            get => nannyId;
            set
            {
                nannyId = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("NannyId"));
                }
            }
        }
        public string NannyLastName
        {
            get => nannyLastName;
            set
            {
                nannyLastName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("NannyLastName"));
                }
            }
        }
        public string NannyFirstName
        {
            get => nannyFirstName;
            set
            {
                nannyFirstName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("NannyFirstName"));
                }
            }
        }
        public string NannyPhone
        {
            get => nannyPhone;
            set
            {
                nannyPhone = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("NannyFirstName"));
                }
            }
        }
        public string NannyAddress
        {
            get => nannyAddress;
            set
            {
                nannyAddress = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("NannyAddress"));
                }
            }
        }
        public DateTime NannyBirth
        {
            get => nannyBirth;
            set
            {
                nannyBirth = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("NannyBirth"));
                }
            }
        }
        public bool IsElevators
        {
            get => isElevators;
            set
            {
                isElevators = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsElevators"));
                }
            }
        }
        public int Nannyflat
        {
            get => nannyflat;
            set
            {
                nannyflat = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Nannyflat"));
                }
            }
        }
        public int NannyExperience
        {
            get => nannyExperience;
            set
            {
                nannyExperience = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("NannyExperience"));
                }
            }
        }
        public int MaxChild
        {
            get => maxChild;
            set
            {
                maxChild = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MaxChild"));
                }
            }
        }
        public int MinAge
        {
            get => minAge; set
            {
                minAge = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MinAge"));
                }
            }
        }
        public int MaxAge
        {
            get => maxAge; set
            {
                maxAge = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MaxAge"));
                }
            }
        }
        public bool IsHours
        {
            get => isHours;
            set
            {
                isHours = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsHours"));
                }
            }
        }
        public double MoneyForHour
        {
            get => moneyForHour;
            set
            {
                moneyForHour = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MoneyForHour"));
                }
            }
        }
        public double MoneyForMonth
        {
            get => moneyForMonth; set
            {
                moneyForMonth = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MoneyForMonth"));
                }
            }
        }
        public bool[] Days
        {
            get => days;
            set
            {
                days = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Days"));
                }
            }
        }
        public string[][] Times
        {
            get => times;
            set
            {
                times = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Times"));
                }
            }
        }
        public bool IsTMTVocation
        {
            get => isTMTVocation;
            set
            {
                isTMTVocation = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsTMTVocation"));
                }
            }
        }
        public string Recommendation
        {
            get => recommendation;
            set
            {
                recommendation = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Recommendation"));
                }
            }
        }
        public bool Isspecial
        {
            get => isspecial;
            set
            {
                isspecial = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Isspecial"));
                }
            }
        }
      
        
        public event PropertyChangedEventHandler PropertyChanged;
        public override string ToString()
        {
            return "id- " + nannyId + "\nfirst name- " + nannyFirstName + "\nlast name- " + nannyLastName + "\nbirth Date- " + nannyBirth.Day+"/"+NannyBirth.Month+"/"+NannyBirth.Year + "\nphone- " + nannyPhone + "\naddress- " + nannyAddress + "\nflat- " + nannyflat + " \nexperience- " + nannyExperience + "\nmax child age- " + maxAge + "\nmax childe- " + maxChild + "\npay for hour" + moneyForHour + "\npay for month- " + moneyForMonth + "\nrecommendation- " + recommendation+"\n";
        }
        public string  MyToString()
        {
            return this.NannyId;
        }
    }
}
