using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace BE
{
    public class Mother: INotifyPropertyChanged
    {
        string momId;
        string momLastName;
        string momFirstName;
        string momPhone;
        string momAddress;
        string babyAddress;
        bool[] days;
        string[][] times;
        string Hearot;
        public Mother()
        {
            days = new bool[6];
            times = new string[6][];
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public string MomId { get => momId; set
            {
                momId = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MomId"));
                }
            }
            }
        public string MomLastName { get => momLastName; set
            {
                momLastName = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MomLastName"));
                }
            }
            }
        public string MomFirstName { get => momFirstName; set
            {
                momFirstName = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MomFirstName"));
                }
            }
            }
        public string MomPhone { get => momPhone; set
            {
                momPhone = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MomPhone"));
                }
            }
        }
        public string MomAddress { get => momAddress; set
            {
                momAddress = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MomAddress"));
                }
            }
        }
        public string BabyAddress
        {
            get => babyAddress; set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BabyAddress"));
                }
                babyAddress = value;
            }
        }
        public bool[] Days { get => days; set
            {
                days = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Days"));
                }
            }
            }
        public string[][] Times { get => times; set
            {
                times = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Times"));
                }
            }
        }
        public string Hearot1 { get => Hearot; set
            {
                Hearot = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Hearot1"));
                }
            }
        }

        public override string ToString()
        {
            return "תעודת זהות " + momId + "\nשם פרטי- " + momFirstName + "\nשם משפחחה- " + momLastName + "\nפלאפון- " + momPhone + "\nכתובת- " + momAddress+"\n";
        }

    }
}
