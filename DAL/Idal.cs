using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface Idal
    {
        void AddNanny(BE.Nanny nanny);
        void DelNanny(BE.Nanny temp);
        void ApdateNanny(BE.Nanny nanny);
        void AddMother(BE.Mother mother);
        void ApdateMother(BE.Mother mother);
        void DelMother(BE.Mother temp);
        void AddChild(BE.Child child);
        void ApdateChild(BE.Child child);
        void DelChild(BE.Child temp);
        void AddContract(BE.Contract contract);
        void ApdateContract(BE.Contract contract);
        void DelContract(BE.Contract temp);
        List<BE.Nanny> GetNannyList();
        List<BE.Mother> GetMotherList();
        List<BE.Child> GetChildMothers(string id);
        List<BE.Contract> GetCOntracts();
        IEnumerable<BE.Nanny> SearchNany(Func<BE.Nanny, bool> predicatt);
        IEnumerable<BE.Child> SearchChild(Func<BE.Child, bool> func);
        IEnumerable<BE.Mother> SearchMother(Func<BE.Mother, bool> func);
        IEnumerable<BE.Contract> SearchContract(Func<BE.Contract, bool> func);
        List<BE.Contract> ContractNanny(string id);
        List<BE.Child> MomChildAtNany(string momid, string nanyid);
        IEnumerable<BE.Contract> SearchContantByChildId(string id);
        List<BE.Child> GetChildList();
        IEnumerable<string> Nomid();
    }
}
