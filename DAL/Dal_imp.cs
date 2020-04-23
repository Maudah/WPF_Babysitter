using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Dal_imp : Idal
    {


        public Dal_imp() { }

        DS.DataSource dsource = DS.DataSource.GetInstanset();
        public void AddNanny(BE.Nanny nanny)
        {
            IEnumerable<BE.Nanny> nanny1;
            nanny1 = this.dsource.SearchNanny(x => x.NannyId == nanny.NannyId);
            if (nanny1 != null)
                throw new Exception("you may only apdate this nanny");
            else

                this.dsource.AddNanny(nanny);
        }
        public void AddMother(BE.Mother mother)
        {
            IEnumerable<BE.Mother> mother1;
            mother1 = this.dsource.SearchMother(x => x.MomId == mother.MomId);
            if (mother1 != null)
                throw new Exception("you may only apdate this mother");
            else
            {

                this.dsource.AddMother(mother);
            }
        }
        public void AddChild(BE.Child child)
        {
            IEnumerable<BE.Child> child1;
            child1 = this.dsource.SearchChild(x => x.ChildId == child.ChildId);
            if (child1 != null)
                throw new Exception("you may only apdate this child");
            else
            {
                if (this.dsource.SearchMother(x => x.MomId == child.MomId) == null)
                    throw new Exception("no mother with this id");
                else
                    this.dsource.AddChild(child);
            }
        }

        public void AddContract(BE.Contract contract)
        {
            BE.Contract.index++;
            contract.ContractCode = BE.Contract.index;

            IEnumerable<BE.Nanny> nanny1;
            nanny1 = this.dsource.SearchNanny(x => x.NannyId == contract.NannyID);

            IEnumerable<BE.Mother> mother1;
            mother1 = this.dsource.SearchMother(x => x.MomId == contract.MomId);
            if (mother1 == null || nanny1 == null)
                throw new Exception("could not add this contract, mother or nanny id did not find");
            else
                this.dsource.AddContract(contract);

        }




        public void DelNanny(BE.Nanny temp)
        {
            this.dsource.RemoveNanny(temp);
        }
        public void DelMother(BE.Mother mother) { dsource.RemoveMother(mother); }
        public void DelChild(BE.Child temp) { dsource.RemoveChild(temp); }
        public void DelContract(BE.Contract contract) { dsource.RemoveContract(contract); }



        public void ApdateNanny(BE.Nanny nanny)
        {
            IEnumerable<BE.Nanny> nanny1;
            nanny1 = this.dsource.SearchNanny(x => x.NannyId == nanny.NannyId);
            if (nanny1 == null)
                throw new Exception("nanny could not find");
            else
            {
                dsource.RemoveNanny(nanny1.Last());
                dsource.AddNanny(nanny);
            }
        }
        public void ApdateMother(BE.Mother mother)
        {
            IEnumerable<BE.Mother> mother1;
            mother1 = this.dsource.SearchMother(x => x.MomId == mother.MomId);
            if (mother1 == null)
                throw new Exception("mother could not find");
            else
            {
                dsource.RemoveMother(mother1.Last());
                dsource.AddMother(mother);
            }
        }
        public void ApdateChild(BE.Child child)
        {
            IEnumerable<BE.Child> child1;
            child1 = this.dsource.SearchChild(x => x.ChildId == child.ChildId);
            if (child1 == null)
                throw new Exception("child could not find");
            else
            {
                dsource.RemoveChild(child1.Last());
                dsource.AddChild(child);
            }
        }
        public void ApdateContract(BE.Contract contract)
        {
            IEnumerable<BE.Contract> contract1;
            contract1 = this.dsource.SearchContract(x => x.ContractCode == contract.ContractCode);
            if (contract1 == null)
                throw new Exception("contract could not find");
            else
            {
                dsource.RemoveContract(contract1.Last());
                dsource.AddContract(contract);
            }
        }

        public List<BE.Nanny> GetNannyList()
        {
            return dsource.NannyList;
        }
        public List<BE.Mother> GetMotherList()
        {
            return dsource.MotherList;
        }
        public List<BE.Child> GetChildMothers(string id)
        {
            return dsource.Childmom(id);
        }
        public List<BE.Child> GetChildList()
        {
            return dsource.Childlist;
        }
        public List<BE.Contract> GetCOntracts() { return this.GetCOntracts(); }

        public IEnumerable<BE.Nanny> SearchNany(Func<BE.Nanny, bool> prediatt = null)

        {
            return this.dsource.SearchNanny(prediatt);
        }
        public IEnumerable<BE.Child> SearchChild(Func<BE.Child, bool> predicatt = null)
        {
            return this.dsource.SearchChild(predicatt);
        }

        public IEnumerable<BE.Mother> SearchMother(Func<BE.Mother, bool> func)
        {
            return this.dsource.SearchMother(func);
        }
        public IEnumerable<BE.Contract> SearchContract(Func<BE.Contract, bool> func)
        {
            return this.dsource.SearchContract(func);
        }
        public List<BE.Child> MomChildAtNany(string momid, string nanyid)
        {
            return dsource.MomChildAtNany(momid, nanyid);

        }
        public List<BE.Contract> ContractNanny(string id)
        {
            return dsource.ContractNanny(id);
        }
        public IEnumerable<BE.Contract> SearchContantByChildId(string id)
        {
            return dsource.SearchContract(x => x.ChildID == id);
        }
        public IEnumerable<string> Nomid()
        {
            return dsource.Nomid();
        }
    }
    //string nannyId,
    //    string nannyLastName,
    //    string nannyFirstName,
    //    string nannyPhone,
    //    string nannyAddress,
    //    string nannyBirth,
    //    bool isElevators,
    //    int nannyflat,
    //    int nannyExperience,
    //    int maxChild,
    //    int minAge,
    //    int maxAge,
    //    bool isHours,
    //    double moneyForHour,
    //    double moneyForMonth,
    //    bool[] days,
    //    string[][] times,
    //    bool isTMTVocation,
    //    string recommendation
}
