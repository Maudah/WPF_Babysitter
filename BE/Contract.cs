using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace BE
{
    public class Contract
    {
        public static int index = 0;
        int contractCode;
        string nannyID;
        string childID;
        bool isMeating;
        bool signing;
        double payForHour;
        double payForMonth;
        bool isHour;
        DateTime startingDate;
        DateTime endingDate;
        string momId;
       
        public Contract()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public int ContractCode { get => contractCode; set{ contractCode = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ContractCode"));
                }
            }
        }
        public string NannyID { get => nannyID; set { nannyID = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("NannyID"));
                }
            }
        }
        public string MomId { get => momId; set { momId = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MomId"));
                }
            }
        }
        public string ChildID { get => childID; set { childID = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ChildID"));
                }
            }
        }
        public bool IsMeating { get => isMeating; set { isMeating = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsMeating"));
                }
            }
        }
        public bool Signing { get => signing; set {signing = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Signing"));
                }
            }
        }
        public double PayForHour { get => payForHour; set { payForHour = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("PayForHour"));
                }
            }
        }
        public double PayForMonth { get => payForMonth; set { payForMonth = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("PayForMonth"));
                }
            }
        }
        public bool IsHour { get => isHour; set {isHour = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsHour"));
                }
            }
        }
        public DateTime StartingDate { get => startingDate; set { startingDate = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("StartingDate"));
                }
            }
        }
        public DateTime EndingDate { get => endingDate; set { endingDate = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("EndingDate"));
                }
            }
        }
      
        public int ContractCode1 { get => contractCode; set { contractCode = value; if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ContractCode1"));
                }
            }
        }

        public override string ToString()
        {
            return "\nconstract code- " + contractCode + "\n nannyID- " + nannyID + " \nchildID- " + childID + " \npayForHour- " + payForHour + " \npayForMonth- " + payForHour + " \nstarting date- " + startingDate.Day+"/"+startingDate.Month+"/" +StartingDate.Year+ "\nending date- " + endingDate.Day+"/"+EndingDate.Month+"/"+endingDate.Year+"\n";
        }
    }
}
