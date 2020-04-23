using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        void AddNanny(BE.Nanny nanny);
        void DelNanny(string id);
        void ApdateNanny(BE.Nanny nanny);
        void AddMother(BE.Mother mother);
        void ApdateMother(BE.Mother mother);
        void DelMother(string id);
        void AddChild(BE.Child child);
        void ApdateChild(BE.Child child);
        void DelChild(string id);
        void AddContract(BE.Contract contract);
        void ApdateContract(BE.Contract contract);
        void DelContract(BE.Contract temp);
        List<BE.Nanny> GetNannyList();
        List<BE.Mother> GetMotherList();
        List<BE.Child> GetChildMothers(string id);
        List<BE.Contract> GetCOntracts();
        int HoursStart(int i, BE.Mother mothertemp);
        int MinutesStart(int i, BE.Mother mothertem);
        int HourEnd(int i, BE.Mother mothertemp);
        int MinutesEnd(int i, BE.Mother mothertemp);
        IEnumerable<BE.Nanny> SearchNany(Func<BE.Nanny, bool> predicatt);
        IEnumerable<BE.Child> SearchChild(Func<BE.Child, bool> func);
        IEnumerable<BE.Mother> SearchMother(Func<BE.Mother, bool> func);
        IEnumerable<BE.Contract> SearchContract(Func<BE.Contract, bool> func);
         List<BE.Nanny> PotentionNanny(BE.Child child);
        List<BE.Nanny> FivePotentionNanny(BE.Child child);
        List<BE.Child> ChildWithoutNanny();
        List<BE.Nanny> TMTNanny();
        IEnumerable<IGrouping<int, BE.Nanny>> NannyByChildAge(bool ismax , bool isorder );
        IEnumerable<BE.Nanny> NannyForSpacialNeeds();
    }
}
