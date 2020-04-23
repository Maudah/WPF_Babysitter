using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BE
{
    public class Child: INotifyPropertyChanged
    {
        string childId;
        string momId;
        DateTime childBirth;
        string childFistName;
        bool specialBoy;
        string specialBoyDetails;
        public event PropertyChangedEventHandler PropertyChanged;
        public string ChildId
        {
            get { return childId; }
            set
            {
                childId = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ChildId"));
                }
            }
        }
        public string MomId { get { return momId; }
            set {
                momId = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MomId"));
                }
            } }
        public DateTime ChildBirth { get => childBirth;
            set { childBirth = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ChildBirth"));
                }
            } }
        public string ChildFistName { get => childFistName; set
            {
                childFistName = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ChildFistName"));
                }
            }
            }
        public bool SpecialBoy { get => specialBoy; set
            {
                specialBoy = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SpecialBoy"));
                }
            }
            }
        public string SpecialBoyDetails { get => specialBoyDetails; set
            {
                specialBoyDetails = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SpecialBoyDetails"));
                }
            }
            }

        public override string ToString()
        {
            return "\nמ.זהות האם " + momId + "\nמס.זהות" + childId + "\nשם פרטי- " + childFistName + "\nת.לידה- " + childBirth.Day+"/"+ChildBirth.Month+"/" +ChildBirth.Year+ "\nצרכים מיוחדים?- " + specialBoy + "\nפרטים מיחדים- " + specialBoyDetails+"\n";
        }
        public string GetChildId()
        {
            return this.ChildId;
        }


    }
}
